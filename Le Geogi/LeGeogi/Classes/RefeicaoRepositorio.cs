using LeGeogi.Interface;
namespace LeGeogi.Classes
{
    public class RefeicaoRepositorio : IRepositorio<Refeicao>
    {
        //Criando um repositório para as refeições
        private List<Refeicao> listaRefeicao = new List<Refeicao>();  
        
        public void Atualiza(int id, Refeicao objeto)
        {
            listaRefeicao[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaRefeicao[id].Excluir();
        }

        public void Insere(Refeicao objeto)
        {
            listaRefeicao.Add(objeto);
        }

        public List<Refeicao> Lista()
        {
            return listaRefeicao;
        }

        public int ProximoId()
        {
            return listaRefeicao.Count;
        }

        public Refeicao RetornaPorId(int id)
        {
            return listaRefeicao[id];
        }
    }
}