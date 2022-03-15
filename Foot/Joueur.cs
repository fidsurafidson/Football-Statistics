using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foot
{
    public class Joueur
    {
        int id;
        String nom;
        int numero;
        int idEquipe;
        String nomEquipe;

        public Joueur() { }

        public Joueur(int ids, String noms, int numeros, int idEquipes)
        {
            this.setId(ids);
            this.setNom(noms);
            this.setNumero(numeros);
            this.setIdEquipe(idEquipes);
        }

        public Joueur(int ids, String noms, int numeros, int idEquipes, String nomEquipes)
        {
            this.setId(ids);
            this.setNom(noms);
            this.setNumero(numeros);
            this.setIdEquipe(idEquipes);
            this.setNomEquipe(nomEquipes);
        }

        public Joueur(String noms, int numeros, int idEquipes)
        {
            this.setNom(noms);
            this.setNumero(numeros);
            this.setIdEquipe(idEquipes);
        }
        public Joueur(int ids, String noms, String nomEquipes)
        {
            this.setId(ids);
            this.setNom(noms);
            this.setNomEquipe(nomEquipes);
        }

        public int getId()
        {
            return id;
        }
        public String getNom()
        {
            return nom;
        }
        public int getNumero()
        {
            return numero;
        }
        public int getIdEquipe()
        {
            return idEquipe;
        }
        public String getNomEquipe()
        {
            return nomEquipe;
        }
        public void setId(int ids)
        {
            this.id = ids;
        }
        public void setId(String ids)
        {
            int idd = int.Parse(ids);
            setId(idd);
        }
        public void setNom(String noms)
        {
            this.nom = noms;
        }
        public void setNumero(int numeros)
        {
            this.numero = numeros;
        }
        public void setNumero(String numeros)
        {
            int numeroo = int.Parse(numeros);
            setNumero(numeroo);
        }
        public void setIdEquipe(int idEquipes)
        {
            this.idEquipe = idEquipes;
        }
        public void setIdEquipe(String idEquipes)
        {
            int idEquipee = int.Parse(idEquipes);
            setIdEquipe(idEquipee);
        }
        public void setNomEquipe(String nomEquipes)
        {
            this.nomEquipe = nomEquipes;
        }
    }
    
}
