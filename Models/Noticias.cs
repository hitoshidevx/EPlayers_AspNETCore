using System;
using System.Collections.Generic;
using System.IO;
using EPlayers_AspNETCore.Interfaces;

namespace EPlayers_AspNETCore.Models
{
    public class Noticias : EplayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Método que cadastra uma linha no csv    .
        /// </summary>
        /// <param name="n"></param>
        public void Create(Noticias n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Método que prepara a linha que vai ser cadastrada com os atributos necessários.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Retorna a linha com os atributos da classe</returns>
        public string PrepararLinha(Noticias n)
        {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        /// <summary>
        /// Método que lê os arquivos da lista feita.
        /// </summary>
        /// <returns></returns>
        public List<Noticias> ReadAll()
        {
            List<Noticias> noticia = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha     = item.Split(";");
                Noticias noticias  = new Noticias();
                noticias.IdNoticia = Int32.Parse(linha[0]);
                noticias.Titulo    = linha[1];
                noticias.Texto     = linha[2];
                noticias.Imagem    = linha[3];


                noticia.Add(noticias);
            }
            return noticia;
        }

        /// <summary>
        /// Método que atualiza e reescreve uma linha.
        /// </summary>
        /// <param name="n"></param>
        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Método que exclue uma linha.
        /// </summary>
        /// <param name="IdNoticia"></param>
        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}