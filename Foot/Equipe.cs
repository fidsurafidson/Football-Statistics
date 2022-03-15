using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foot
{
    public class Equipe
    {
        int id;
        String nom;

        public Equipe() { }

        public Equipe(int idd, String nomm)
        {
            this.setId(idd);
            this.setNom(nomm);
        }

        public Equipe(String nomm)
        {
            this.setNom(nomm);
        }

        public int getId()
        {
            return id;
        }
        public String getNom()
        {
            return nom;
        }
        public void setId(int idd)
        {
            this.id = idd;
        }
        public void setNom(String nomm)
        {
            this.nom = nomm;
        }
    }
}
