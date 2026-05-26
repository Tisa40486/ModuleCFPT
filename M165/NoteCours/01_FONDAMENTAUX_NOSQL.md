# 📚 COURS COMPLET: NoSQL - MongoDB & ArangoDB
## M165 - Évaluation Complète

---

## TABLE DES MATIÈRES
1. [Fondamentaux NoSQL](#fondamentaux)
2. [CAP Theorem](#cap-theorem)
3. [MongoDB](#mongodb)
4. [ArangoDB](#arangodb)
5. [Comparaison](#comparaison)

---

# FONDAMENTAUX

## 🎯 C'est quoi une Base de Données NoSQL ?

### **Explication enfant (5 ans)**

Imagine une **armoire à jouets** :
- Une **base SQL** (relationnelle) = une armoire **très organisée** avec des tiroirs numérotés. Chaque tiroir contient toujours le même **type** d'objets et dans le **même ordre**
- Une **base NoSQL** = une armoire **plus flexible** où tu peux ranger tes affaires comme tu veux

### **Explication technique**

| Aspect | SQL (Relationnel) | NoSQL |
|--------|------------------|-------|
| Structure | Tables rigides, colonnes prédéfinies | Documents flexibles, JSON-like |
| Schéma | Strict et obligatoire | Flexible, sans schéma |
| Scalabilité | Verticale (augmenter 1 gros serveur) | Horizontale (plusieurs petits serveurs) |
| Transactions | ACID (sûr mais lent) | BASE (rapide mais moins sûr) |
| Requêtes | SQL standardisé | Langage spécifique à chaque DB |

---

## 📊 ACID vs BASE

### **ACID** (SQL Traditionnel)

```
ACID = Atomicity, Consistency, Isolation, Durability
```

**Atomicity (Atomicité)**
```
Exemple: Transfert bancaire de 100€ de compte A vers compte B
- SOIT A perd 100€ ET B gagne 100€
- SOIT rien ne change

Pas d'état intermédiaire où A a perdu 100€ mais B ne l'a pas reçu!
```

**Consistency (Cohérence)**
```
La base est TOUJOURS dans un état valide
- Si on dit "solde minimum = 0€", c'est TOUJOURS vrai
- Jamais un solde de -50€
```

**Isolation (Isolation)**
```
2 transactions ne s'interfèrent pas
- Transaction 1 modifie données
- Transaction 2 ne voit rien tant que T1 n'est pas finie
- Pas de lecture incohérente
```

**Durability (Pérennité)**
```
Une fois validée, c'est gravé dans le marbre
- Même si le serveur crash juste après
- Même si la lumière s'éteint
- Les données restent
```

### **BASE** (NoSQL)

```
BASE = Basically Available, Soft state, Eventual consistency
```

**Basically Available (Essentiellement Disponible)**
```
Le système répond TOUJOURS
- Même si pas parfait
- Pas de blocage
- Priorise la rapidité
```

**Soft State (État Changeant)**
```
Les données peuvent changer toutes seules
- Synchronisation asynchrone entre serveurs
- 2 serveurs peuvent avoir des données différentes temporairement
- C'est normal, ça se synchronisera
```

**Eventual Consistency (Cohérence Événtuelle)**
```
À la fin, tout devient cohérent
- Pas immédiatement, mais "à terme"
- Comme quand tu cries dans une montagne
- L'écho revient pas immédiatement, mais il arrive
```

---

## 📡 CAP THEOREM (Le Triangle Magique)

### **Le Concept**

Imagine un restaurant avec **3 branches** dans des villes différentes. Tu peux choisir **2 sur 3** :

```
        ╔═════════════════════════════════╗
        ║   CAP THEOREM (Choisis 2 sur 3)  ║
        ╚═════════════════════════════════╝
        
            Consistency (C)
                   ▲
                   │
                   │ (Cohérence)
                   │ Tous les clients
                   │ voient les mêmes
                   │ données
                   │
     ┌─────────────┼─────────────┐
     │             │             │
     │             │             │
Partition ◀───────┼─────────► Availability
 Tolerance         │              (A)
(P)            CP  │  CA        (Disponibilité)
             CP+AP │  AP+CA    Réponse rapide
Continues à   │  AP            toujours
fonctionner   │
même si panne │
                
Les bases au coin choisissent:
- CP = Cohérence + Partitionnement
- CA = Cohérence + Disponibilité  
- AP = Disponibilité + Partitionnement
```

### **Explication Simple**

**Scenario**: Ton app bancaire a 3 serveurs en 3 pays différents.

**Serveur 1 (France)** et **Serveur 2 (Allemagne)** se battent (problème réseau).

Tu dois choisir :

#### **CP - Cohérence + Partitionnement**
```
Priorité: TOUT LE MONDE doit voir la même chose
Action: Bloque les transactions
Problème: L'app peut devenir lente ou bloquer
Cas d'usage: Banques (erreur = catastrophe)
Exemple: PostgreSQL, MongoDB (par défaut)
```

#### **CA - Cohérence + Disponibilité**
```
Priorité: Réponse rapide ET tout cohérent (si réseau OK)
Action: Assume pas de panne réseau majeure
Problème: Se casse si vraie panne réseau
Cas d'usage: Applis classiques sur 1 seul data center
Exemple: Bases relationnelles classiques (MySQL, PostgreSQL)
```

#### **AP - Disponibilité + Partitionnement**
```
Priorité: TOUJOURS répondre, même si incohérent temporairement
Action: Continue à fonctionner, se synchronise après
Problème: 2 serveurs peuvent voir des données différentes temporairement
Cas d'usage: DNS, cache, réseaux sociaux
Exemple: DynamoDB, Cassandra, CouchDB
```

---

## 🔄 ISOLATION DES TRANSACTIONS

### **Le Problème : Transactions Concurrentes**

Imagine 2 personnes retirant de l'argent d'un compte joint en même temps :

```
Compte = 100€

Personne A retire 40€
Personne B retire 30€

QU'EST-CE QUI SE PASSE ?

Mauvais scenario (dirty read):
- A lit 100€ (correct)
- B lit 100€ (correct)
- A retire 40€ → reste 60€ en base
- B retire 30€ → reste 70€ en base
- Problème: 70€ reste, mais on a retiré 70€ au total!
  La cohérence est brisée!

C'est le "dirty read" - on lit des données
qu'une autre transaction est en train de modifier
```

### **Les 4 Problèmes d'Isolation**

#### **1. Dirty Read** 🟥
```
T1 modifie une ligne MAIS ne commite pas
T2 lit cette ligne modifiée
T1 annule (rollback) la modification

Résultat: T2 a lu des données qui n'existent pas!

Exemple:
- T1: "Augmente solde de 100€" (pas encore validé)
- T2: "Lis le solde" → voit les 100€
- T1: "Ooops, j'ai changé d'avis" (rollback)
- T2 a vu 100€ qui n'existaient pas!
```

#### **2. Non-Repeatable Read** 🟨
```
T1 lit une ligne
T2 modifie CETTE LIGNE et commite
T1 relit la même ligne

Résultat: 2 lectures différentes pour la même ligne!

Exemple:
- T1: "Lis le solde" → 100€
- T2: "Augmente solde de 50€" (validé)
- T1: "Relis le solde" → 150€
- La même ligne a 2 valeurs différentes!
```

#### **3. Phantom Read** 🟦
```
T1 exécute une requête "SELECT ... WHERE ..."
T2 insère/supprime des lignes et commite
T1 exécute LA MÊME REQUÊTE

Résultat: Nombre de lignes différent!

Exemple:
- T1: "SELECT * WHERE solde > 100" → 5 lignes
- T2: "INSERT une nouvelle ligne" (validé)
- T1: "SELECT * WHERE solde > 100" → 6 lignes!
- Fantasme: une ligne "fantôme" apparaît
```

#### **4. Serialization Anomaly** 🟪
```
Situation complexe où les transactions
s'interfèrent de manière subtile
même si pas de dirty/non-repeatable/phantom read
```

### **Les 4 Niveaux d'Isolation SQL**

```
┌─────────────────────────────────────────────────────────┐
│ NIVEAU 1: READ UNCOMMITTED (le plus faible)            │
├─────────────────────────────────────────────────────────┤
│ Problèmes possibles: Dirty, Non-Rep, Phantom, Serial   │
│ Performance: ⚡⚡⚡ (très rapide)                         │
│ Sécurité: 🔓 (très faible)                             │
│ Cas d'usage: Rapports approximatifs OK                 │
└─────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────┐
│ NIVEAU 2: READ COMMITTED (courant)                      │
├─────────────────────────────────────────────────────────┤
│ Bloque: Dirty ✓                                         │
│ Problèmes: Non-Rep, Phantom, Serial                    │
│ Performance: ⚡⚡ (rapide)                               │
│ Sécurité: 🔐 (moyen)                                   │
│ Cas d'usage: Plupart des apps web                      │
└─────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────┐
│ NIVEAU 3: REPEATABLE READ (strict)                      │
├─────────────────────────────────────────────────────────┤
│ Bloque: Dirty ✓, Non-Rep ✓                            │
│ Problèmes: Phantom, Serial                             │
│ Performance: ⚡ (moyen)                                 │
│ Sécurité: 🔒 (bon)                                    │
│ Cas d'usage: Transactions financières                  │
└─────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────┐
│ NIVEAU 4: SERIALIZABLE (le plus strict)                │
├─────────────────────────────────────────────────────────┤
│ Bloque: Tout ✓✓✓✓                                      │
│ Problèmes: Aucun                                        │
│ Performance: (très lent, transactions en série)        │
│ Sécurité: 🔒🔒🔒 (parfait)                             │
│ Cas d'usage: Situations extrêmes (très rare)          │
└─────────────────────────────────────────────────────────┘
```

### **NoSQL et l'Isolation**

```
⚠️ IMPORTANT POUR L'EXAM: 

NoSQL = PAS d'isolation des transactions!

Même les mises à jour validées ne sont pas 
visibles immédiatement partout!

C'est le compromis du BASE theorem pour avoir
plus de rapidité et disponibilité.
```

---

## 🏗️ ARCHITECTURES MULTI-SERVEURS

### **Pourquoi Plusieurs Serveurs ?**

```
1 serveur = problèmes :
- S'il crash, tout est down
- Si trop d'utilisateurs, ça ralentit
- Données pas sauvegardées ailleurs
```

### **Réplication** (Copie complète des données)

```
┌──────────────┐
│   Maître (M) │◀─── Écritures + Lectures
│   Data: A,B  │
└──────┬───────┘
       │ Copie
       ▼
┌──────────────┐
│  Esclave (E) │◀─── Lectures uniquement
│   Data: A,B  │
└──────────────┘

Avantages:
✓ Sauvegarde automatique
✓ Lectures plus rapides (réparties sur esclaves)
✓ Tolérance aux pannes

Inconvénients:
✗ Les esclaves sont pas à jour immédiatement
✗ Gaspillage d'espace (données dupliquées 3x)
```

### **Clustering** (Partitionnement : données divisées)

```
Collection: utilisateurs (1 million)

┌──────────────┐
│  Serveur 1   │◀─── utilisateurs: A-F (alphabétique)
│  Data: A-F   │
└──────────────┘

┌──────────────┐
│  Serveur 2   │◀─── utilisateurs: G-M
│  Data: G-M   │
└──────────────┘

┌──────────────┐
│  Serveur 3   │◀─── utilisateurs: N-Z
│  Data: N-Z   │
└──────────────┘

Avantages:
✓ Chaque serveur porte moins de données
✓ Requêtes parallélisées
✓ Scale infiniment (ajoute serveur = + capacité)

Inconvénients:
✗ Si 1 serveur crash, on perd 1/3 des données
✗ Requêtes entre partitions = compliquées
✗ Rebalancer les données si serveur ajouté
```

### **Architecture Maître-Esclave**

```
MAÎTRE (Primary)
┌─────────────────────┐
│  Accepte les WRITES │
│  Accepte les READS  │
│  Données: A,B,C,D   │
└──────────┬──────────┘
           │ Réplication (copie asynchrone)
           ▼
       ┌─────────────────────┐
       │ ESCLAVE 1 (Secondary) │
       │ Refus des WRITES     │
       │ Accepte les READS    │
       │ Données: A,B,C,D     │
       └─────────────────────┘
           ┌─────────────────────┐
           │ ESCLAVE 2 (Secondary) │
           │ Refus des WRITES     │
           │ Accepte les READS    │
           │ Données: A,B,C,D     │
           └─────────────────────┘

Scenario:
1. Client écrit "UPDATE X"
   → Va AU MAÎTRE
   → Maître met à jour localement
   → Maître envoie l'ordre aux esclaves
   
2. Esclaves exécutent le même UPDATE
   → Tout le monde a X = valeur nouvelle
   → Pas immédiat (asynchrone) mais garantit cohérence
```

### **Architecture Multi-Maîtres**

```
MAÎTRE 1           MAÎTRE 2
┌──────────┐      ┌──────────┐
│ Accepte  │      │ Accepte  │
│ WRITES   │◄────►│ WRITES   │
│ A,B,C,D  │      │ A,B,C,D  │
└──────────┘      └──────────┘

Problème: Conflit!
- Client 1: "UPDATE B = 100" (Maître 1)
- Client 2: "UPDATE B = 200" (Maître 2)
- Qui a raison ?

Solution: Mécanismes de résolution de conflit
(timestamp, version vector, etc.)

Avantages:
✓ Les 2 maîtres peuvent avoir du trafic
✓ Pas de point unique de défaillance

Inconvénients:
✗ Très complexe
✗ Gestion des conflits difficile
✗ Pas de vraie cohérence garantie
```

---

## 📈 SCALABILITÉ

### **Vertical Scaling (Monter en Puissance)**

```
1 serveur avec:
- CPU: 2 cores
- RAM: 4 GB
- Disque: 500 GB

       ↓ Upgrade ↓

1 serveur avec:
- CPU: 64 cores
- RAM: 256 GB
- Disque: 10 TB

Avantages:
✓ Facile à mettre en place
✓ Pas de complexité d'architecture
✓ Bonne cohérence (1 serveur)

Inconvénients:
✗ Très cher (1 mega-serveur)
✗ Limite physique (pas de CPU plus puissant)
✗ Pendant l'upgrade: serveur offline (panne)
✗ Pas de sauvegarde si ça crash
```

### **Horizontal Scaling (Ajouter Serveurs)**

```
3 petits serveurs (standard)
- CPU: 4 cores chacun
- RAM: 16 GB chacun
- Disque: 1 TB chacun

Au lieu de:
1 mega serveur

Avantages:
✓ Moins cher (3 × standard < 1 × ultra-puissant)
✓ Upgrade sans downtime (1 serveur à la fois)
✓ Redondance (si 1 crash, 2 restent)
✓ Scale infiniment (ajoute des serveurs)
✓ Distribution géographique possible

Inconvénients:
✗ Architecture plus complexe
✗ Synchronisation des données
✗ Gestion des conflits
✗ Partitionnement des données
```

### **Quand l'Utiliser ?**

| Situation | Solution |
|-----------|----------|
| Petit site, forte cohérence requise | Vertical |
| Énorme volume de données | Horizontal |
| Besoin de haute disponibilité | Horizontal + Replication |
| Utilisateurs mondiaux | Horizontal + Plusieurs zones |
| Budget limité | Horizontal (plusieurs petits) |
| Mission critique (banque) | Horizontal + Réplication redondante |

---

## 🗂️ STRUCTURES D'INDEXATION

### **Concept : Pourquoi des Index ?**

Sans index :
```
SELECT * FROM users WHERE email = "john@example.com"

La base DOIT lire TOUS les 1 million d'utilisateurs
pour trouver John. C'est long! ⏱️⏱️⏱️
```

Avec index :
```
CREATE INDEX idx_email ON users(email)

Quand tu cherches "john@example.com":
La base utilise une structure rapide (arbre)
pour trouver directement le bon utilisateur ⚡
```

### **Types d'Index**

#### **1. B-Tree Index** (Plus courant)

```
Structure arborescente équilibrée

Exemple: Index sur email

         [f]
        /   \
      [d]   [j]
      / \    / \
    [b] [e][h] [m]
    /|  |\ |\  |\
   a b  d e h i j l m

Requête: WHERE email STARTS WITH "j"
→ Va directement au nœud [j] et sous-arbre
→ Très rapide, pas besoin de scanner tout

Utilisé pour: Recherche, tri, intervalle
Exemple: BETWEEN, <, >, =
```

#### **2. Hash Index**

```
Fonction de hash: email → nombre

john@example.com → Hash → 12345
alice@example.com → Hash → 67890

Table directe:
[12345] → john's data
[67890] → alice's data

Avantages:
✓ Recherche exacte très rapide

Inconvénients:
✗ Pas de tri possible
✗ Pas de BETWEEN
✗ Collision de hash possibles

Utilisé pour: Exact match uniquement (=)
```

#### **3. Full-Text Index**

```
Exemple: Index sur contenu d'article

Article: "MongoDB est une base NoSQL populaire"

Index crée:
"mongodb" → article_id
"base" → article_id
"nosql" → article_id
"populaire" → article_id

Requête: WHERE CONTAINS("nosql")
→ Trouve l'article immédiatement
→ Peut ignorer les petits mots (est, une, est)

Utilisé pour: Recherche textuelle, articles, commentaires
```

#### **4. Spatial Index**

```
Utilisé pour données géographiques

Point: Paris (48.856°N, 2.292°E)

Index crée une grille spatiale:
[Zone 1] → ville A, ville B
[Zone 2] → ville C, ville D

Requête: "Restaurants près de moi (1km)"
→ Cherche seulement dans zone proche
→ Pas besoin de calculer distance pour TOUS

Utilisé pour: Maps, GPS, localisation
```

#### **5. Compound Index**

```
Index sur PLUSIEURS colonnes

CREATE INDEX idx_name_email ON users(name, email)

Équipe pour:
- WHERE name = "John"
- WHERE name = "John" AND email = "john@ex.com"

Ne marche PAS pour:
- WHERE email = "john@ex.com" (pas le premier champ)
- WHERE email = "john@ex.com" AND name = "John"
  (ordre inversé)

Ordre IMPORTE!
```

---

Fin Partie 1 - Fondamentaux

Prêt pour MongoDB et ArangoDB ? 🚀
