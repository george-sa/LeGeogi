namespace LeGeogi.Classes
{
    public class Refeicao : EntidadeBase
    {
        //Atributos
        private Categoria Categoria {get; set;}
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private double Preco { get; set; }
        private bool Excluido {get; set;}
        
        //Métodos
        public Refeicao (int id, Categoria categoria, string titulo, string descricao, double preco )
        {
            this.Id = id;
            this.Categoria = categoria;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Preco = preco;
            this.Excluido = false;
        }
        
        //Sobrescrever
        public override string ToString()
        {
            string retorno = "";
            retorno += "Categoria: " + this.Categoria + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Preço: R$ " + this.Preco + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        //Retorna para listagem de refeições
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}