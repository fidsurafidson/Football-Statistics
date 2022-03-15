using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foot
{
    public class FeuilleMatchJoueur
    {
        int id;
        int idMatch;
        int idEquipe;
        String equipe;
        int idJoueur;
        String joueur;
	    int minuteJoue;
	    int ballonTouche;
	    int tir;
	    int tirCadre;
	    int but;
	    int passeDecisive;

        public FeuilleMatchJoueur(int ids, int idMatchs, int idEquipes, int idJoueurs, int minuteJoues, int ballonTouches, int tirs, int tirCadres, int buts, int passeDecisives)
        {
            this.setId(ids);
            this.setIdMatch(idMatchs);
            this.setIdEquipe(idEquipes);
            this.setIdJoueur(idJoueurs);
            this.setMinuteJoue(minuteJoues);
            this.setBallonTouche(ballonTouches);
            this.setTir(tirs);
            this.setTirCadre(tirCadres);
            this.setBut(buts);
            this.setPasseDecisive(passeDecisives);
        }
        public FeuilleMatchJoueur(int idMatchs, int idEquipes, int idJoueurs, int minuteJoues, int ballonTouches, int tirs, int tirCadres, int buts, int passeDecisives)
        {
            this.setIdMatch(idMatchs);
            this.setIdEquipe(idEquipes);
            this.setIdJoueur(idJoueurs);
            this.setMinuteJoue(minuteJoues);
            this.setBallonTouche(ballonTouches);
            this.setTir(tirs);
            this.setTirCadre(tirCadres);
            this.setBut(buts);
            this.setPasseDecisive(passeDecisives);
        }
        public FeuilleMatchJoueur(int ids, int idMatchs, String equipes, String joueurs, int minuteJoues, int ballonTouches, int tirs, int tirCadres, int buts, int passeDecisives)
        {
            this.setId(ids);
            this.setIdMatch(idMatchs);
            this.setEquipe(equipes);
            this.setJoueur(joueurs);
            this.setMinuteJoue(minuteJoues);
            this.setBallonTouche(ballonTouches);
            this.setTir(tirs);
            this.setTirCadre(tirCadres);
            this.setBut(buts);
            this.setPasseDecisive(passeDecisives);
        }
        public FeuilleMatchJoueur(int tirs, int tirCadres, int buts)
        {
            this.setTir(tirs);
            this.setTirCadre(tirCadres);
            this.setBut(buts);
        }

        public int getId()
        {
            return id;
        }
        public int getIdMatch()
        {
            return idMatch;
        }
        public int getIdEquipe()
        {
            return idEquipe;
        }
        public String getEquipe()
        {
            return equipe;
        }
        public int getIdJoueur()
        {
            return idJoueur;
        }
        public String getJoueur()
        {
            return joueur;
        }
        public int getMinuteJoue()
        {
            return minuteJoue;
        }
        public int getBallonTouche()
        {
            return ballonTouche;
        }
        public int getTir()
        {
            return tir;
        }
        public int getTirCadre()
        {
            return tirCadre;
        }
        public int getBut()
        {
            return but;
        }
        public int getPasseDecisive()
        {
            return passeDecisive;
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
        public void setIdMatch(int idMatchs)
        {
            this.idMatch = idMatchs;
        }
        public void setIdMatch(String idMatchs)
        {
            int idM = int.Parse(idMatchs);
            setIdMatch(idM);
        }
        public void setIdEquipe(int idEquipes)
        {
            this.idEquipe = idEquipes;
        }
        public void setIdEquipe(String idEquipes)
        {
            int idE = int.Parse(idEquipes);
            setIdEquipe(idE);
        }
        public void setEquipe(String equipes)
        {
            this.equipe = equipes;
        }
        public void setIdJoueur(int idJoueurs)
        {
            this.idJoueur = idJoueurs;
        }
        public void setIdJoueur(String idJoueurs)
        {
            int idJ = int.Parse(idJoueurs);
            setIdJoueur(idJ);
        }
        public void setJoueur(String joueurs)
        {
            this.joueur = joueurs;
        }
        public void setMinuteJoue(int minuteJoues)
        {
            this.minuteJoue = minuteJoues;
        }
        public void setMinuteJoue(String minuteJoues)
        {
            int min = int.Parse(minuteJoues);
            setMinuteJoue(min);
        }
        public void setBallonTouche(int ballonTouches)
        {
            this.ballonTouche = ballonTouches;
        }
        public void setBallonTouche(String ballonTouches)
        {
            int ballon = int.Parse(ballonTouches);
            setBallonTouche(ballon);
        }
        public void setTir(int tirs)
        {
            this.tir = tirs;
        }
        public void setTir(String tirs)
        {
            int tirr = int.Parse(tirs);
            setTir(tirr);
        }
        public void setTirCadre(int tirCadres)
        {
            this.tirCadre = tirCadres;
        }
        public void setTirCadre(String tirCadres)
        {
            int tirC = int.Parse(tirCadres);
            setTirCadre(tirC);
        }
        public void setBut(int buts)
        {
            this.but = buts;
        }
        public void setBut(String buts)
        {
            int butt = int.Parse(buts);
            setBut(butt);
        }
        public void setPasseDecisive(int passes)
        {
            this.passeDecisive = passes;
        }
        public void setPasseDecisive(String passes)
        {
            int passeD = int.Parse(passes);
            setPasseDecisive(passeD);
        }
    }
}
