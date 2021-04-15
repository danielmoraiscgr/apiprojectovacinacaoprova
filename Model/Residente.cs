using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProjectoVacinacao.Data;

namespace ProjectoVacinacao.Model
{
    public class Residente
    {
    
        public int DId { get; set; }

        public string DNomeCompleto { get; set; }

        public string DCpf { get; set; }

        public string DTelefone { get; set; }

        public string DEmail { get; set; }

        public int DIdade { get; set; }

        private readonly DbContext _dbContext;

        public Residente()
        {
            _dbContext = new DbContext();
        }

        public List<Residente> ListarResidentes()
        {
            var db = File.ReadAllText(_dbContext.CaminhoBanco());

            var listaResidentes = JsonConvert.DeserializeObject<List<Residente>>(db);

            return listaResidentes;

        }

        public bool AtualizarDbRes(List<Residente> listaResidentes)
        {
            var json = JsonConvert.SerializeObject(listaResidentes, Formatting.Indented);
            File.WriteAllText(_dbContext.CaminhoBanco(), json);
            return true;
        }

        public Residente AlterarResidente(int id, Residente residente)
        {
            var listaResidentes = this.ListarResidentes();

            var itemIndex = listaResidentes.FindIndex(r => r.DId == id);

            if (itemIndex >= 0)
            {
                residente.DId = id;
                listaResidentes[itemIndex] = residente;

            }else
            {
                return null;
            }

            AtualizarDbRes(listaResidentes);
            return residente;
        }

        public Residente InserirResidente(Residente residente)
        {
            var listaResidentes = this.ListarResidentes();

            var maxId = listaResidentes.Max(r => r.DId);

            residente.DId = maxId + 1;
            listaResidentes.Add(residente);

            AtualizarDbRes(listaResidentes);
            return residente;         
        }

        public bool DeletarResidente(int id)
        {
            var listaResidentes = this.ListarResidentes();

            var itemIndex = listaResidentes.FindIndex(r => r.DId == id);

            if (itemIndex >= 0)
            {
                listaResidentes.RemoveAt(itemIndex);
            } else
            {
                return false;
            }

            AtualizarDbRes(listaResidentes);
            return true; 

        }
    }
}
