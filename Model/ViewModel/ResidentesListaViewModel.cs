using System;
namespace ProjectoVacinacao.ViewModel
{
    public class ResidentesListaViewModel
    {
        public ResidentesListaViewModel(int dId, string dNomeCompleto, string dEmail, string dTelefone)
        {
            DId = dId;
            DNomeCompleto = dNomeCompleto;
            DEmail = dEmail;
            DTelefone = dTelefone;
        }

        public int DId { get; set; }
        public string DNomeCompleto { get; set; }
        public string DEmail { get; set; }
        public string DTelefone { get; set; }

    }
}
