# 🎯 SYNTHÈSE FINALE & PRÉPARATION EXAM

---

## QUESTIONS TYPE D'EXAMEN (Explications Complètes)

### **Q1: Explique le Théorème CAP**

**Réponse attendue:**

Le théorème CAP affirme qu'un système distribué ne peut avoir que 2 des 3 propriétés :

```
┌─────────────────────────────────────────────┐
│ CAP = Consistency + Availability + Partition │
│       (Choisis 2)                           │
└─────────────────────────────────────────────┘

1. CONSISTENCY (Cohérence)
   - Tous les clients voient les mêmes données
   - Au même moment
   - Aucune incohérence

2. AVAILABILITY (Disponibilité)
   - Le système réagit TOUJOURS
   - Pas d'erreur "serveur indisponible"
   - Réponse garantie

3. PARTITION TOLERANCE (Tolérance aux Pannes)
   - Le système fonctionne même si un nœud crash
   - Même si réseau partitionné (2 parties)
```

**Exemple Concret:**

```
Scenario: Transfert bancaire entre 2 branches

Branche A (serveur 1) et Branche B (serveur 2)
Réseau coupé entre A et B

CP (Cohérence + Partitionnement):
  "Personne ne peut transférer jusqu'à rétablissement"
  → Pas disponible, mais cohérent
  → Les 2 branches refusent les transactions

CA (Cohérence + Disponibilité):
  "Les 2 branches peuvent transférer normalement"
  → Disponible, mais si partition:
  → Données incohérentes (2 soldes différents!)

AP (Disponibilité + Partitionnement):
  "Les 2 branches fonctionnent indépendamment"
  → Disponible et tolère partition
  → Mais données incohérentes jusqu'à sync
```

---

### **Q2: Différence ACID vs BASE ?**

**Réponse attendue:**

```
ACID = pour SQL (relationnel)
┌──────────────────────────────────────────────┐
│ Atomicity (Atomicité)                        │
│ → Tout ou rien                               │
│ Exemple: Transfert: perte OU gain, pas moyen │
├──────────────────────────────────────────────┤
│ Consistency (Cohérence)                      │
│ → Base TOUJOURS valide                       │
│ Exemple: Solde négatif = impossible          │
├──────────────────────────────────────────────┤
│ Isolation (Isolation)                        │
│ → Transactions indépendantes                 │
│ Exemple: 2 transactions ne se voient pas     │
├──────────────────────────────────────────────┤
│ Durability (Pérennité)                       │
│ → Une fois validée = gravé                   │
│ Exemple: Crash = données sauvegardées        │
└──────────────────────────────────────────────┘


BASE = pour NoSQL (MongoDB, etc.)
┌──────────────────────────────────────────────┐
│ Basically Available (Essentiellement Dispo)  │
│ → Toujours réponse (peut être fausse)        │
│ Exemple: "Service temporairement indisponible"│
├──────────────────────────────────────────────┤
│ Soft State (État Changeant)                  │
│ → Données pas synchronisées tout de suite    │
│ Exemple: 2 serveurs = données différentes    │
├──────────────────────────────────────────────┤
│ Eventual Consistency (Cohérence Événtuelle)  │
│ → À la fin, tout se synchronise              │
│ Exemple: Après quelques secondes, OK         │
└──────────────────────────────────────────────┘

PRIORITÉS:
ACID  = Sécurité > Performance
BASE  = Performance > Sécurité (à court terme)
```

---

### **Q3: Pourquoi NoSQL et pas SQL pour certains cas ?**

**Réponse attendue:**

```
SQL Bon Pour:
✓ Données structurées (colonnes fixes)
✓ Transactions ACID (banque)
✓ Requêtes jointes complexes
✓ Schéma strict

NoSQL Bon Pour:
✓ Volume énorme (scaling horizontal)
✓ Données flexibles (JSON)
✓ Pas besoin de ACID strict
✓ Haute disponibilité
✓ Graphes/Relations (MongoDB fail, ArangoDB win)

Exemple Réel:
- Netflix: Millions de vidéos, millions d'utilisateurs
  → SQL: Un serveur → bottleneck
  → NoSQL: Plusieurs serveurs, partition par pays → rapide

- Banque: Transferts d'argent
  → SQL: ACID = 100€ garanti
  → NoSQL: Risque incohérence = pas bon
```

---

### **Q4: Schéma vs Sans Schéma?**

**Réponse attendue:**

```
SCHÉMA STRICT (SQL)
┌──────────────────────────────────────────┐
│ CREATE TABLE users (                     │
│   id INT PRIMARY KEY,                    │
│   name VARCHAR(100) NOT NULL,            │
│   age INT,                               │
│   email VARCHAR(100)                     │
│ );                                       │
│                                          │
│ TOUS les users ont ces 4 colonnes        │
│ Impossible d'ajouter un champ "phone"    │
│ à un user sans ALTER TABLE TOUTE TABLE   │
└──────────────────────────────────────────┘

Avantages:
✓ Structure claire
✓ Moins d'erreurs
✓ Validation garantie

Inconvénients:
✗ Rigide
✗ Modification = ALTER TABLE lent
✗ Schéma changeant = difficulté


SANS SCHÉMA (NoSQL)
┌──────────────────────────────────────────┐
│ db.users.insert({                        │
│   _id: 1,                                │
│   name: "John"                           │
│ })                                       │
│                                          │
│ db.users.insert({                        │
│   _id: 2,                                │
│   name: "Alice",                         │
│   phone: "06123456789"  ← Different!     │
│ })                                       │
│                                          │
│ OK! Pas de problème                      │
└──────────────────────────────────────────┘

Avantages:
✓ Flexible
✓ Modifications faciles
✓ Évolution rapide

Inconvénients:
✗ Pas de validation
✗ Risque incohérence
✗ Code doit vérifier
```

---

### **Q5: MongoDB Aggregation Pipeline?**

**Réponse attendue:**

```
C'est une succession d'étapes qui transforment les données

Analogie: Tuyau d'usine
- Étape 1: Ôter les défauts ($match)
- Étape 2: Trier par couleur ($group)
- Étape 3: Compter par pile ($count)

db.collection.aggregate([
  { $stage1: {...} },  ← Données brutes
  { $stage2: {...} },  ← Résultat stage1 → input stage2
  { $stage3: {...} }   ← Résultat stage2 → output final
])

Les principales:
- $match   : WHERE
- $group   : GROUP BY
- $sort    : ORDER BY
- $limit   : LIMIT
- $project : SELECT
- $lookup  : JOIN
- $unwind  : Déplier arrays

Utilité:
✓ Requêtes analytiques
✓ Rapide (opérations côté serveur)
✓ Pas besoin de code client
```

---

### **Q6: MongoDB vs ArangoDB?**

**Réponse attendue:**

```
MONGODB
┌─────────────────────────────────────────┐
│ Type: Document Database                 │
│ Modèle: Collections de documents JSON   │
│ Forces:                                 │
│   ✓ Simple et rapide                    │
│   ✓ Grand écosystème                    │
│   ✓ Documents flexibles                 │
│ Faiblesses:                             │
│   ✗ Relations = compliquées             │
│   ✗ Joins = pas natif (lookup expensive)│
│   ✗ Graphe = lent                       │
│ Cas d'usage:                            │
│   - Blog, e-commerce, apps classiques   │
└─────────────────────────────────────────┘

ARANGODB
┌─────────────────────────────────────────┐
│ Type: Multi-Model Database              │
│ Modèle: Documents + Graphe + Key-Value  │
│ Forces:                                 │
│   ✓ Documents flexibles                 │
│   ✓ Graphe NATIF (très rapide)         │
│   ✓ Relations triviales                 │
│ Faiblesses:                             │
│   ✗ Écosystème plus petit              │
│   ✗ Documentation moins rich            │
│ Cas d'usage:                            │
│   - Réseaux sociaux, recommandations    │
│   - Taxonomies, arborescences           │
└─────────────────────────────────────────┘

Comparaison simple:
MongoDB  = Coffre-fort de documents
ArangoDB = Réseau de documents reliés
```

---

### **Q7: Replication vs Clustering?**

**Réponse attendue:**

```
REPLICATION (Copie identique)
┌─────────────────────────────────┐
│                                 │
│    PRIMARY (Maître)             │
│  ┌──────────────────────────┐   │
│  │ Data: A, B, C, D         │   │
│  │ Lectures + Écritures     │   │
│  └──────────────────────────┘   │
│         ↓ Copie                 │
│    SECONDARY (Esclave)          │
│  ┌──────────────────────────┐   │
│  │ Data: A, B, C, D (copie) │   │
│  │ Lectures uniquement       │   │
│  └──────────────────────────┘   │
│                                 │
└─────────────────────────────────┘

Avantages:
✓ Sauvegarde automatique
✓ Lectures distribuées
✓ Tolérance panne (secondaire → primary)

Inconvénients:
✗ Données dupliquées (espace)
✗ Secondaires pas à jour immédiatement
✗ Replication lag (délai de sync)


CLUSTERING (Partition/Sharding)
┌─────────────────────────────────┐
│                                 │
│  Shard 1 (A-F)                  │
│  ┌──────────────────────────┐   │
│  │ Data: Alice, Bob, ...    │   │
│  └──────────────────────────┘   │
│                                 │
│  Shard 2 (G-M)                  │
│  ┌──────────────────────────┐   │
│  │ Data: George, Harry, ... │   │
│  └──────────────────────────┘   │
│                                 │
│  Shard 3 (N-Z)                  │
│  ┌──────────────────────────┐   │
│  │ Data: Nancy, Zoe, ...    │   │
│  └──────────────────────────┘   │
│                                 │
└─────────────────────────────────┘

Avantages:
✓ Chaque serveur = moins de données
✓ Requêtes parallélisées
✓ Scale infini (ajoute shards)

Inconvénients:
✗ Si 1 shard crash = perte de données
✗ Requêtes multi-shards = complexes
✗ Rebalancer si nouveau shard
```

---

### **Q8: Index? Pourquoi c'est important?**

**Réponse attendue:**

```
SANS INDEX:
"Trouve John dans 1 million d'utilisateurs"
→ Scanner TOUS les 1M documents
→ O(n) = très lent

AVEC INDEX:
"Trouve John"
→ Utilise structure rapide (B-Tree)
→ O(log n) = très rapide

Types d'Index:
1. B-Tree (courant) → Recherche, intervalle
2. Hash → Exact match uniquement
3. Full-Text → Recherche textuelle
4. Spatial → Géographie (GPS)
5. Compound → Plusieurs colonnes

Quand créer:
✓ Champs recherchés souvent
✓ FILTER, WHERE, ORDER BY
✗ Pas si données changeantes (slow insert)
```

---

## RÉSUMÉ SUPER RAPIDE (1 PAGE)

```
╔═════════════════════════════════════════════════════════════════╗
║         NOSQL EXAM CHEAT SHEET - 60 SECONDES VERSION            ║
╠═════════════════════════════════════════════════════════════════╣

CAP THEOREM:
  CP: Cohérence + Partitionnement (banques)
  CA: Cohérence + Disponibilité (SQL classique)
  AP: Disponibilité + Partitionnement (DNS, cache)

ACID vs BASE:
  ACID = Strict, sûr (SQL)
  BASE = Rapide, flexible (NoSQL)

MONGODB:
  - Documents JSON flexibles
  - Collections sans schéma
  - CRUD: insert, find, update, delete
  - Aggregation Pipeline pour analyses
  - Replica Set pour replication

ARANGODB:
  - Documents + Graphes + Key-Value
  - AQL pour requêtes (type SQL)
  - Edges pour relations
  - Traversée graphe rapide
  - OUTBOUND/INBOUND pour graphe

REPLICATION:
  Primary → Écritures
  Secondary → Lectures seulement
  Copie asynchrone

CLUSTERING (Sharding):
  Données partitionnées par clé
  Chaque serveur = sous-ensemble
  Requêtes parallélisées

INDEX:
  B-Tree: Recherche générale
  Hash: Exact match
  Full-Text: Texte
  Spatial: GPS/Géo

QUAND UTILISER:
  MongoDB  → Documents simples, pas de graphe
  ArangoDB → Relations, recommandations, graphes
  SQL      → ACID strict, schéma rigide

╚═════════════════════════════════════════════════════════════════╝
```

---

## QUESTIONS POSSIBLES À L'EXAM ÉCRITE (45 min)

### **Type A: Théorique (5-10 minutes)**

1. Expliquez le théorème CAP et donnez un exemple
2. Différence entre ACID et BASE?
3. Replication vs Clustering?
4. Pourquoi NoSQL pour le big data?
5. Schéma strict vs sans schéma?

### **Type B: Code MongoDB (10-15 minutes)**

6. Écrivez une aggregation pipeline pour:
   "Calculer le prix moyen par pizzeria"

7. Écrivez un INSERT/UPDATE/DELETE

8. Comment faire un JOIN en MongoDB?

### **Type C: Code ArangoDB (10-15 minutes)**

9. Écrivez une requête pour:
   "Trouver tous les amis d'Alice"

10. Écrivez OUTBOUND/INBOUND

11. Comment implémenter recommandations?

### **Type D: Comparaison (5 minutes)**

12. MongoDB ou ArangoDB pour X scenario?

---

## CONSEILS POUR L'EXAM

### **Examen Écrit (45 min, sur papier)**

```
✓ À faire:
  - Lire toutes les questions avant de commencer
  - Commencer par celles qu'on connaît bien
  - Dessiner des diagrammes (CAP, Replica Set)
  - Donner des exemples concrets
  - Expliquer clairement même si pas sûr

✗ À éviter:
  - Écrire du code complet (c'est explications)
  - Aller trop vite
  - Oublier les détails
  - Inventer de trucs non vérifiés
```

### **Examen Informatique (sans réseau)**

```
✓ À faire:
  - Avoir un IDE avec intellisense
  - Tester le code avant de livrer
  - Code commenté et lisible
  - Documentation dans le dossier
  - README.md clair

✓ À inclure dans le dossier:
  - Code source (.cs, .js)
  - Documentation (.md)
  - Exemples d'exécution
  - Explications des concepts
  - Screenshots de résultats

✗ À éviter:
  - Code mal indé
  - Pas de commentaires
  - Oublier la documentation
  - Aucun test
```

---

## CHECKLIST AVANT L'EXAM

```
□ Vérifier installer MongoDB en local
□ Vérifier installer ArangoDB en Docker
□ Tester connexion C# → MongoDB
□ Tester connexion Node.js → ArangoDB
□ Réviser les opérateurs ($match, $group, etc.)
□ Réviser AQL (FOR, FILTER, OUTBOUND)
□ Comprendre CAP et ACID vs BASE
□ Faire au moins 5 exercices d'aggregation
□ Faire au moins 5 requêtes graphe
□ Revoir les slides du cours
□ Relire ce document complet
□ Dormir la veille! (pas de cramming 2h avant)
```

---

Vous êtes **100% prêt** pour cet examen ! 🎓

Bonne chance ! 🚀
