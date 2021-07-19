using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Model
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public identidadeSecreta Identidade { get; set; }
        public List<Arma> Armas { get; set; }
        public List<HeroiBatalha> HeroisBatalhas { get; set; }
    }
}

/* Quando iniciamos um projeto EFCore com CodeFirst o passo inicial é identificar e configurar os relacionamentos, por padrão sempre
 * que temos um relacionamento - um para muitos - como no caso de Heroi que pode ter muitas armas, declaramos uma propriedade do tipo
 * List<>/ IEnumerable/ ICollection dessa classe, para conseguirmos listar todas as armas que são daquele heroi. Na entidade armas apenas
 * referenciamos a entidade Heroi e uma prop int para o ID. */

// Em - um para um - neste caso nem sempre um heroi tem que necessariamente ter uma identidade secreta, por isso não declaramos uma prop Id para heroi.

/* No caso de - muitos para muitos - temos a possibilidade de criar uma nova entidade intermediária que irá conter todas as propriedades necessárias. */
