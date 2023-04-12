using System.Data;
using System.Drawing.Printing;
using Oracle.ManagedDataAccess.Client;

namespace FormEtiquetaRX
{
    public class EtiquetarxController
    {
        public Dictionary<string, object> BuscarDados(string pedido)
        {
            string oradb = "Data Source=ip-do-servidor:porta/orcl;User Id=usuario;Password=senha;";

            using (OracleConnection conn = new OracleConnection(oradb))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = @"SELECT
	                    CONCAT('ATEND.: ', PR.CD_ATENDIMENTO) ATENDIMENTO
	                    ,CONCAT('DT.ATEND.: ', TO_CHAR(AT.HR_ATENDIMENTO, 'DD/MM/YYYY HH24:MI:SS')) DTATENDIMENTO
	                    ,CONCAT('MATRI.: ', PA.CD_PACIENTE) MATRICULA
	                    ,CONCAT('DT.NASC: ', CONCAT( TO_CHAR(PA.DT_NASCIMENTO, 'DD/MM/YYYY '), CONCAT('PEDIDO:', :pedrx)) ) DTNASCIMENTO
	                    ,CONCAT('NOME..: ', PA.NM_PACIENTE) NOME
	                    ,CONCAT('MÃE...: ', PA.NM_MAE) MAE
	                    ,CONCAT('CPF...: ', PA.NR_CPF) CPF
	                    ,CONCAT('CNS...: ', PA.NR_CNS) CNS
	                    ,CONCAT('ENDER.: ', PA.DS_ENDERECO) ENDERECO
	                    ,CONCAT('BAIRRO: ', PA.NM_BAIRRO) BAIRRO
	                    ,CONCAT('CIDADE: ', CONCAT(CI.NM_CIDADE, CONCAT(' - ', CI.CD_UF))) CIDADE
	                    ,CONCAT('CEP...: ', PA.NR_CEP) CEP
                    FROM DBAMV.PED_RX PR
                    INNER JOIN DBAMV.ATENDIME AT
                    ON AT.CD_ATENDIMENTO = PR.CD_ATENDIMENTO
                    INNER JOIN DBAMV.PACIENTE PA
                    ON PA.CD_PACIENTE = AT.CD_PACIENTE
                    INNER JOIN DBAMV.CIDADE CI
                    ON PA.CD_CIDADE = CI.CD_CIDADE
                    WHERE PR.CD_PED_RX = :pedrx";
                        cmd.Parameters.Add("pedrx", pedido);
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        Dictionary<string, object> etiqueta = new Dictionary<string, object>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            etiqueta[dr.GetName(i)] = dr[i].ToString();
                            // Console.WriteLine(dr[i].ToString());
                            // Console.WriteLine(dr.GetName(i));
                            // Console.WriteLine(dr.GetName(i), dr.GetValue(i));
                        }

                        return etiqueta;

                        // return etiqueta;

                        conn.Dispose();
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ocorreu um erro: " + e.Message);
                        return null;
                    }
                }
            }
        }

        public void ImprimirDados(List<string> dados, string impressora)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings = new PrinterSettings();
            pd.PrinterSettings.PrinterName = impressora;
            pd.PrintPage += new PrintPageEventHandler((sender, ev) => PrintPage(sender, ev, dados));
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 550, 150);
            pd.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev, List<string> dados)
        {
            Font fonte = new Font("Arial", 9);
            SolidBrush pincel = new SolidBrush(Color.Black);
            float lineHeight = fonte.GetHeight(ev.Graphics);
            float yPos = ev.MarginBounds.Top;
            /*Pen pen = new Pen(Color.Black, 1);
            Rectangle borderRect = new Rectangle(ev.MarginBounds.Left, ev.MarginBounds.Top, ev.MarginBounds.Width, ev.MarginBounds.Height);
            ev.Graphics.DrawRectangle(pen, borderRect);*/


            foreach (string dado in dados)
            {
                ev.Graphics.DrawString(dado, fonte, pincel, ev.MarginBounds.Left, yPos, new StringFormat());
                yPos += lineHeight;
            }
        }


    }
}
