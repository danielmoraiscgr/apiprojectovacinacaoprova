using System;
namespace ProjectoVacinacao.Model.ViewModel
{
    public class ResidenteViewModel
    {
        public ResidenteViewModel(int dId, string dNomeCompleto, string dCpf, string dTelefone, string dEmail, int dIdade)
        {
            DId = dId;
            DNomeCompleto = dNomeCompleto;
            DCpf = dCpf;
            DTelefone = dTelefone;
            DEmail = dEmail;
            DIdade = dIdade;
        }

        public int DId { get; set; }

        public string DNomeCompleto { get; set; }

        public string DCpf { get; set; }

        public string DTelefone { get; set; }

        public string DEmail { get; set; }

        public int DIdade { get; set; }
    }
}
