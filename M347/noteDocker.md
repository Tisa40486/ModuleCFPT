# Note docker

---

## virtualisation \& conteneurisation



### **VM** => robuste mais couteuse



Avantage :

 - isolation totale,

 - ressources réserve totalement dédiées,

 - permet l'installation de différents OS

 

Inconvenients :

 - temps de démarrage élevé,

 - réserve des ressources fixes CPU/Ram prises sur le systeme hote

---

### **Docker** => léger et isolé



Avantage :

 - démarrage quasi-instantané

 - ne reserve pas de ressources inutlisée

 - reduit les couts d'infrastructure

 - portabilité élevé

 

Inconvenients :

isolation moindre que les VM







##### Push in dockerhub

<user>/<repository>









Stack **LAMP**

* **L**inux
* **A**pash
* **M**ariaDB
* **P**HP



le conteneur est immuable, les donnees


ligne de cmd 
- docker --version
- docker pull hello-world
- docker run hello-world
- docker images
- docker run -it ubuntu bash
- docker login
- docker commit mon-serveur-web [user]/mon-nginx-personnalise
- docker push [user]/mon-nginx-personnalise
- docker run debian echo "Hello world"
- exit (for bash)
