using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Utils
{
    public class ObjectDumper
    {
        private readonly int depth;
        private int level;
        private int pos;
        private TextWriter writer;

        private ObjectDumper(int depth)
        {
            this.depth = depth;
        }

        public static string Dump(object element, string fieldPrefix = null)
        {
            var stringWriter = new StringWriter();
            Write(element, 10, stringWriter, fieldPrefix);
            string fullStr = stringWriter.ToString();
            if (fullStr.EndsWith(stringWriter.NewLine))
            {
                fullStr = fullStr.Substring(0, fullStr.Length - stringWriter.NewLine.Length);
            }
            return fullStr;
        }

        public static string DumpJson(object element, Formatting aa = Formatting.None, JsonSerializerSettings settings = null)
        {
            var jsonString = "";
            try
            {
                jsonString = settings != null
                    ? JsonConvert.SerializeObject(element, aa, settings)
                    : JsonConvert.SerializeObject(element, aa);

            }
            catch (Exception)
            {
                // ignored
            }
            //Console.WriteLine(jsonString);
            return jsonString;
        }

        public static void Write(object element)
        {
            Write(element, 0);
        }

        public static void Write(object element, int depth)
        {
            Write(element, depth, Console.Out);
        }

        public static void Write(object element, int depth, TextWriter log, string fieldPreffix = null)
        {
            var dumper = new ObjectDumper(depth);
            dumper.writer = log;
            dumper.WriteObjectRecursive(null, element, fieldPreffix);
        }

        private void Write(string s)
        {
            if (s != null)
            {
                writer.Write(s);
                pos += s.Length;
            }
        }

        private void WriteIndent()
        {
            for (int i = 0; i < level; i++) writer.Write("  ");
        }

        private void WriteLine()
        {
            writer.WriteLine();
            pos = 0;
        }

        private void WriteTab()
        {
            Write("  ");
            while (pos % 8 != 0) Write(" ");
        }

        private void WriteObjectRecursive(string prefix, object element, string fieldPreffix)
        {
            //Console.Out.WriteLine("Prefix:" + prefix + " obj:" + element.GetType() + "=" + element);
            bool isPrimitiveValue = IsPrimitiveValue(element);
            bool isCollection = (element as IEnumerable) != null;
            if (isPrimitiveValue) //Primitive Atribute
            {
                WriteIndent();
                Write(prefix);
                WriteValue(element);
                WriteLine();
            }
            else if (isCollection) // Collection
            {
                WriteEnumerableRecursive(prefix, element as IEnumerable, fieldPreffix);
            }
            else // Complex Object 
            {
                WriteIndent();
                Write(prefix);

                MemberInfo[] members = element.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
                var fldInfos = new List<FldInfo>();
                foreach (MemberInfo m in members)
                {
                    FldInfo fldInfo = new FldInfo { m = m, f = m as FieldInfo, p = m as PropertyInfo }.Build(element);
                    if (fldInfo.Skip) continue;
                    fldInfos.Add(fldInfo);
                }

                //fldInfos.Sort(delegate(FldInfo x, FldInfo y) { return x.IsPlain().CompareTo(x.IsPlain()); });
                //List<FldInfo> infoPlain = fldInfos.Where(x => x.FIsPlain).ToList();
                for (int i = 0; i < fldInfos.Count; i++)
                {
                    FldInfo fldInfo = fldInfos[i];

                    object value = fldInfo.FValue;
                    if (i > 0) WriteTab();
                    Write((fieldPreffix ?? "") + fldInfo.m.Name);
                    Write("=");
                    if (fldInfo.FIsPlain)
                    {
                        if (EsEstructuraPlana(fldInfo.FType)) value = value == null ? null : value.ToString();
                        WriteValue(value);
                    }
                    else
                    {
                        if (typeof(IEnumerable).IsAssignableFrom(fldInfo.FType))
                            Write("{list}");
                        else
                            Write("{ojbt}");
                    }
                }
                if (fldInfos.Count > 0) WriteLine();
                if (level < depth)
                {
                    List<FldInfo> infoComplex = fldInfos.Where(x => !x.FIsPlain).ToList();
                    for (int i = 0; i < infoComplex.Count; i++)
                    {
                        FldInfo fldInfo = infoComplex[i];

                        object value = fldInfo.FValue;
                        if (value != null)
                        {
                            level++;
                            WriteObjectRecursive(fldInfo.m.Name + ": ", value, fieldPreffix);
                            level--;
                        }
                    }
                }
            }
        }

        internal static bool IsPrimitiveValue(object element)
        {
            return element == null || element is ValueType || element is string;
        }

        private void WriteEnumerableRecursive(string prefix, IEnumerable enumerableElement, string fieldPreffix)
        {
            foreach (object item in enumerableElement)
            {
                if (IsPrimitiveValue(item))
                {
                    WriteIndent();
                    Write(prefix);
                    WriteValue(item);
                    WriteTab();
                }
                else if (item is IEnumerable && !(item is string))
                {
                    WriteIndent();
                    Write(prefix);
                    Write("...|");
                    if (level < depth)
                    {
                        level++;
                        WriteObjectRecursive(prefix, item, fieldPreffix);
                        level--;
                    }
                    WriteLine();
                }
                else
                {
                    WriteObjectRecursive(prefix, item, fieldPreffix);
                }
            }
        }

        internal static bool EsEstructuraPlana(Type t)
        {
            return t.Name.Equals("Auditoria") || t.Name.Equals("RespuestaEstado");
        }

        private void WriteValue(object o)
        {
            if (o == null)
            {
                Write("null");
            }
            else if (o is DateTime)
            {
                Write(((DateTime)o).ToFileTimeUtc());
            }
            else if (o is ValueType || o is string)
            {
                Write(o.ToString());
            }
            else if (o is IEnumerable)
            {
                Write("...X");
            }
            else
            {
                Write("{ }");
            }
        }
    }

    internal class FldInfo
    {
        public bool FIsPlain;
        public Type FType;
        public Object FValue;
        public bool Skip;
        public FieldInfo f;
        public MemberInfo m;
        public PropertyInfo p;

        public FldInfo Build(Object element)
        {
            var odAnnotation = ReadObjectDumperAnnotation();
            Skip = (f == null && p == null) || (odAnnotation != null && odAnnotation.Excluir);
            if (!Skip)
            {
                //try
                //{
                FType = f != null ? f.FieldType : p.PropertyType;
                FValue = f != null ? f.GetValue(element) : p.GetValue(element, null);

                //FIsPlain = ObjectDumper.IsPrimitiveValue(element);//FType.IsValueType || FType == typeof (string) || ObjectDumper.EsEstructuraPlana(FType);
                FIsPlain = FType.GetTypeInfo().IsPrimitive || FType == typeof(string) || FType == typeof(DateTime) || FType == typeof(DateTime?) || FType == typeof(double) || FType == typeof(double?) || ObjectDumper.EsEstructuraPlana(FType);


                if (!FIsPlain) //Inferir tipos que pueden ser enumerables
                {
                    IEnumerable elementEnumerable = (FValue as IEnumerable);
                    if (elementEnumerable != null)
                    {
                        IEnumerator enumerator = elementEnumerable.GetEnumerator();
                        bool hasElements = enumerator.MoveNext();
                        object firstElement = hasElements ? enumerator.Current : null;
                        if (hasElements && ObjectDumper.IsPrimitiveValue(firstElement))  // Array de primitivos
                        {
                            StringBuilder buf = new StringBuilder();
                            buf.Append("{");
                            foreach (var unitGkey in elementEnumerable)
                            {
                                if (buf.Length > 1) buf.Append(",");
                                buf.Append(unitGkey);
                            }
                            buf.Append("}");

                            FIsPlain = true;
                            FValue = buf.ToString();
                        }
                    }


                }
                if (!FIsPlain && odAnnotation != null)
                {
                    FIsPlain = true;
                    string fieldPrefix = odAnnotation.Preffix;
                    if (fieldPrefix != null && !fieldPrefix.EndsWith(".")) fieldPrefix += ".";
                    FValue = "{" + ObjectDumper.Dump(FValue, fieldPrefix) + "}";

                }


                //}
                //catch (Exception e)
                //{
                //    Skip = true;
                //}
            }
            return this;
        }

        private ObjectDumperAnnotation ReadObjectDumperAnnotation()
        {
            List<ObjectDumperAnnotation> atributos = m.GetCustomAttributes<ObjectDumperAnnotation>(true).ToList();
            ObjectDumperAnnotation odAnnotation = (ObjectDumperAnnotation)(atributos.Any() ? atributos[0] : null);
            return odAnnotation;
        }
    }
}
