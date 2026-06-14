Le projet doit respecter les valeurs et les principes du Domain-Driven Design tactique


# Définitions du Domain-Driven Design

## Domaine (domain)
Une sphère de connaissances, d’influence ou d’activité. Le domaine du logiciel correspond au sujet ou au secteur dans lequel l’utilisateur applique le programme.

## Modèle (model)
Un système d’abstractions qui décrit certains aspects sélectionnés d’un domaine et qui peut être utilisé pour résoudre des problèmes liés à ce domaine.

## Langage omniprésent (ubiquitous language)
Un langage structuré autour du modèle du domaine et utilisé par tous les membres de l’équipe au sein d’un contexte délimité (bounded context) afin de relier toutes les activités de l’équipe au logiciel.

## Contexte (context)
L’environnement dans lequel apparaît un mot ou un énoncé et qui en détermine la signification. Les énoncés relatifs à un modèle ne peuvent être compris qu’à l’intérieur d’un contexte.

## Contexte délimité (bounded context)
La description d’une frontière (généralement un sous-système ou le périmètre de travail d’une équipe particulière) à l’intérieur de laquelle un modèle spécifique est défini et applicable.

# Le Domain-Driven Design Tactique s'appelle le Model-Driven Design

## Conception pilotée par le modèle (Model-Driven Design)

Le fait de relier étroitement le code à un modèle sous-jacent lui donne du sens et rend ce modèle pertinent.

Si la conception, ou une partie centrale de celle-ci, ne correspond pas au modèle du domaine, alors ce modèle a peu de valeur et la justesse du logiciel devient douteuse. En même temps, les correspondances complexes entre les modèles et les fonctions de conception sont difficiles à comprendre et, en pratique, impossibles à maintenir lorsque la conception évolue. Une séparation dangereuse s’installe alors entre l’analyse et la conception, de sorte que les connaissances acquises dans chacune de ces activités ne nourrissent plus l’autre.

Tirez du modèle la terminologie utilisée dans la conception ainsi que la répartition fondamentale des responsabilités. Le code devient alors une expression du modèle ; ainsi, une modification du code peut également constituer une modification du modèle. Ses effets doivent alors se répercuter sur l’ensemble des autres activités du projet.

Cependant, faire correspondre l’implémentation de manière trop rigide au modèle exige généralement des outils et des langages de développement qui prennent en charge un paradigme de modélisation, comme la programmation orientée objet.

Par conséquent :

Concevez une partie du système logiciel de façon à refléter le modèle du domaine de manière très littérale, afin que la correspondance soit évidente. Réexaminez régulièrement le modèle et modifiez-le pour qu’il soit implémenté plus naturellement dans le logiciel, tout en cherchant à ce qu’il reflète une compréhension plus profonde du domaine. Exigez un modèle unique qui remplisse efficacement ces deux objectifs, tout en soutenant un langage omniprésent (ubiquitous language) fluide et cohérent.

## Objets-valeurs (Value Objects)

Certains objets décrivent ou calculent une caractéristique d’une chose.

De nombreux objets ne possèdent aucune identité conceptuelle.

Le suivi de l’identité des entités est essentiel, mais attribuer une identité à d’autres objets peut nuire aux performances du système, ajouter du travail d’analyse et brouiller le modèle en donnant l’impression que tous les objets sont de même nature. La conception logicielle est une lutte permanente contre la complexité. Nous devons établir des distinctions afin que les traitements particuliers ne soient appliqués que lorsqu’ils sont réellement nécessaires.

Cependant, si nous considérons cette catégorie d’objets uniquement comme l’absence d’identité, nous n’enrichissons ni notre boîte à outils ni notre vocabulaire. En réalité, ces objets possèdent leurs propres caractéristiques et leur propre importance dans le modèle. Ce sont les objets qui décrivent les choses.

Par conséquent :

Lorsque vous ne vous intéressez qu’aux attributs et à la logique d’un élément du modèle, classez-le comme un objet-valeur (Value Object).

Faites en sorte qu’il exprime clairement la signification des attributs qu’il transporte et fournisse les fonctionnalités associées. Considérez l’objet-valeur comme immuable (immutable). Toutes les opérations qu’il expose doivent être des fonctions sans effet de bord (side-effect-free functions), c’est-à-dire des fonctions qui ne dépendent d’aucun état mutable et n’en modifient aucun.

N’attribuez aucune identité à un objet-valeur et évitez ainsi les complexités de conception nécessaires à la gestion et à la persistance des entités.


## Services

Parfois, ce n’est tout simplement pas une « chose ».

Certains concepts du domaine ne se prêtent pas naturellement à une modélisation sous forme d’objets. Forcer une fonctionnalité métier à devenir la responsabilité d’une entité ou d’un objet-valeur déforme soit la définition de l’objet fondé sur le modèle, soit conduit à la création d’objets artificiels dépourvus de véritable signification.

Par conséquent :

Lorsqu’un processus ou une transformation importante du domaine ne constitue pas une responsabilité naturelle d’une entité ou d’un objet-valeur, ajoutez cette opération au modèle sous la forme d’une interface autonome déclarée comme un service (Service).

Définissez un contrat de service (service contract), c’est-à-dire un ensemble d’assertions concernant les interactions avec ce service (voir Assertions). Exprimez ces assertions dans le langage omniprésent (ubiquitous language) propre à un contexte délimité (bounded context) particulier.

Donnez au service un nom explicite, qui deviendra lui aussi un élément du langage omniprésent.

Exemple (DDD)

Dans un domaine bancaire :

CompteBancaire → Entité (possède une identité).
Montant → Objet-valeur (décrit une valeur monétaire).
ServiceDeVirement → Service.

Le virement d'argent entre deux comptes est une opération métier importante, mais elle n'appartient naturellement ni à un compte unique ni à un montant. Elle implique plusieurs objets du domaine et représente un processus métier. Il est donc pertinent de la modéliser sous la forme d'un service de domaine.

## Agrégats (Aggregates)

Il est difficile de garantir la cohérence des modifications apportées à des objets dans un modèle comportant des associations complexes. Les objets sont censés maintenir leur propre état interne cohérent, mais ils peuvent être affectés de manière imprévue par des changements survenus dans d’autres objets qui en constituent pourtant des parties conceptuelles.

Des mécanismes prudents de verrouillage de base de données peuvent amener plusieurs utilisateurs à se bloquer mutuellement sans nécessité et rendre le système difficile, voire impossible, à utiliser. Des problèmes similaires apparaissent lorsque les objets sont répartis sur plusieurs serveurs ou lorsque des transactions asynchrones sont mises en œuvre.

Par conséquent :

Regroupez les entités et les objets-valeurs en agrégats (Aggregates) et définissez des frontières claires autour de chacun d’eux.

Choisissez une entité qui servira de racine d’agrégat (Aggregate Root) et n’autorisez les objets externes à conserver des références qu’à cette racine. Les références aux membres internes de l’agrégat ne doivent être transmises que temporairement dans le cadre d’une opération unique.

Définissez les propriétés et les invariants de l’agrégat dans son ensemble, puis confiez leur maintien soit à la racine de l’agrégat, soit à un mécanisme dédié du framework.

Utilisez les mêmes frontières d’agrégat pour gouverner :

les transactions ;
la distribution des données et des objets.

À l’intérieur d’un agrégat, appliquez les règles de cohérence de manière synchrone.

Entre plusieurs agrégats, gérez les mises à jour de manière asynchrone.

Conservez un agrégat complet sur un même serveur. En revanche, différents agrégats peuvent être répartis sur plusieurs nœuds ou serveurs.

Lorsque les décisions de conception relatives aux transactions ou à la distribution ne semblent plus être naturellement guidées par les frontières des agrégats, remettez le modèle en question. Le scénario métier révèle peut-être une nouvelle compréhension importante du domaine. De tels ajustements améliorent souvent l’expressivité et la flexibilité du modèle tout en résolvant les problèmes de cohérence transactionnelle et de distribution.

Exemple (DDD)

Dans un système de commande e-commerce :

Agrégat Commande

Commande (racine d’agrégat)
LigneDeCommande
AdresseLivraison
MontantTotal

Les objets externes peuvent référencer uniquement Commande.

❌ Mauvais exemple :

LigneDeCommande ligne = repository.getLigne(id);
ligne.modifierQuantite(10);

✅ Bon exemple :

Commande commande = repository.getCommande(id);
commande.modifierQuantiteProduit(produitId, 10);

La racine Commande garantit les invariants métier :

une commande doit contenir au moins une ligne ;
le montant total doit être cohérent avec les lignes ;
une commande expédiée ne peut plus être modifiée.

Ainsi, toute cohérence métier est protégée à l'intérieur de l'agrégat et les autres parties du système n'accèdent jamais directement aux objets internes.

## Référentiels (Repositories)

Accès aux agrégats par requêtes exprimées dans le langage omniprésent.

La multiplication des associations navigables utilisées uniquement pour retrouver des objets finit par brouiller le modèle. Dans les modèles matures, les requêtes expriment souvent des concepts métier. Cependant, les requêtes peuvent également poser de nombreux problèmes.

La complexité technique des infrastructures d'accès aux bases de données finit rapidement par envahir le code client. Les développeurs sont alors tentés de simplifier excessivement la couche métier (domain layer), ce qui rend le modèle de domaine de moins en moins pertinent.

Un framework de requêtes peut encapsuler une grande partie de cette complexité technique, permettant aux développeurs de récupérer les données nécessaires de manière plus automatisée ou déclarative. Toutefois, cela ne résout qu'une partie du problème.

Des requêtes non maîtrisées peuvent accéder directement à certains attributs des objets, violant ainsi l'encapsulation. Elles peuvent également instancier directement des objets internes à un agrégat, en contournant la racine de l'agrégat. Dans ce cas, les règles métier ne peuvent plus être correctement appliquées. La logique métier migre progressivement vers les requêtes et le code applicatif, tandis que les entités et les objets-valeurs ne deviennent plus que de simples conteneurs de données.

Par conséquent :

Pour chaque type d'agrégat nécessitant un accès global, créez un Repository qui donne l'illusion d'une collection en mémoire contenant tous les objets du type de racine d'agrégat concerné.

Exposez cet accès à travers une interface globale bien connue.

Le Repository doit fournir :

des méthodes d'ajout d'objets ;
des méthodes de suppression d'objets ;
des méthodes de recherche fondées sur des critères compréhensibles par les experts métier.

Ces méthodes encapsulent les détails liés au stockage et aux technologies de persistance.

Les méthodes de recherche doivent retourner :

des objets complètement instanciés ;
ou des collections d'objets répondant aux critères ;
ou éventuellement des proxys permettant un chargement différé (lazy loading) tout en donnant l'illusion d'agrégats complets.

Créez des Repositories uniquement pour les racines d'agrégat qui nécessitent réellement un accès direct.

Maintenez la logique applicative centrée sur le modèle métier et déléguez entièrement les responsabilités de stockage et d'accès aux objets aux Repositories.

Exemple (DDD)

Supposons un agrégat Commande :

public interface CommandeRepository {

    Commande trouverParId(CommandeId id);

    List<Commande> trouverCommandesEnAttente();

    List<Commande> trouverParClient(ClientId clientId);

    void sauvegarder(Commande commande);

    void supprimer(Commande commande);
}

Le code métier utilise alors le Repository :

Commande commande = commandeRepository.trouverParId(id);

commande.validerPaiement();

commandeRepository.sauvegarder(commande);

Au lieu de :

String sql =
"SELECT * FROM commandes WHERE id = ?";

ResultSet rs = connection.executeQuery(sql);

La couche métier ne connaît ni SQL, ni la base de données, ni l'ORM utilisé.

Rôle du Repository dans DDD

Le Repository agit comme une frontière entre :

Domaine Infrastructure
Entités Base de données
Objets-valeurs  SQL
Agrégats    ORM
Règles métier   API de stockage

Son objectif est de permettre aux développeurs de manipuler des agrégats métier plutôt que des mécanismes de persistance.

Une règle souvent citée en DDD est :

« Les Repositories parlent le langage du domaine, pas le langage de la base de données. »

Ainsi, des méthodes comme :

trouverCommandesEnRetard()
trouverParClient()
trouverFacturesImpayees()

sont préférables à :

findByStatusAndDate()
findByColumnX()
executeNativeQuery()

car elles expriment directement les concepts du métier et participent au maintien du langage omniprésent (Ubiquitous Language).

Get smarter responses, upload files and images, and more.

## Événements de domaine (Domain Events)

Quelque chose s’est produit dans le domaine, et les experts métier s’y intéressent.

Une entité est responsable du suivi de son état et des règles qui régissent son cycle de vie. Cependant, si l’on souhaite comprendre les causes réelles des changements d’état, cela n’est généralement pas explicite. Il peut alors devenir difficile d’expliquer comment le système est arrivé à son état actuel.

Les journaux d’audit peuvent permettre de retracer l’historique, mais ils ne sont pas adaptés à une utilisation dans la logique métier elle-même. De même, les historiques de changements d’état permettent d’accéder aux versions précédentes des entités, mais ils ignorent la signification des changements. Le traitement de ces informations devient alors purement procédural et est souvent relégué en dehors de la couche métier.

Un problème similaire apparaît dans les systèmes distribués. L’état global d’un système distribué ne peut pas toujours être maintenu de manière parfaitement cohérente à tout moment. On garantit la cohérence interne des agrégats, tout en acceptant que certaines modifications soient propagées de manière asynchrone. Lorsque les changements se propagent à travers les nœuds d’un réseau, il devient difficile de gérer les mises à jour arrivant hors ordre ou provenant de sources différentes.

Par conséquent :

Modélisez les informations relatives aux activités du domaine sous forme d’une série d’événements discrets. Représentez chaque événement comme un objet du domaine.

Ces événements sont distincts des événements système, qui reflètent le fonctionnement interne du logiciel, même si un événement système est souvent associé à un événement de domaine — soit pour réagir à celui-ci, soit pour transporter des informations vers d’autres parties du système.

Un événement de domaine est une partie à part entière du modèle : il représente quelque chose qui s’est produit dans le domaine.

Ignorez les activités non pertinentes du domaine, tout en rendant explicites les événements que les experts métier souhaitent suivre, consommer ou associer à des changements d’état dans d’autres objets du modèle.

Rôle des événements de domaine

Dans un système distribué, l’état d’une entité peut être reconstruit à partir des événements de domaine connus par un nœud donné. Cela permet de maintenir un modèle cohérent même en l’absence d’une vision globale complète du système.

Les événements de domaine sont généralement immutables, car ils représentent des faits passés.

Structure typique d’un événement de domaine

Un événement de domaine contient généralement :

une description de l’événement (ce qui s’est passé) ;
la date et l’heure de l’occurrence ;
l’identité des entités impliquées.

Souvent, il contient aussi :

un horodatage indiquant quand l’événement a été enregistré dans le système ;
l’identité de la personne ou du processus qui l’a enregistré.
Exemple d’événement de domaine

❌ Approche implicite (état sans signification métier) :

commande.setStatut(PAYEE);

On sait que l’état a changé, mais pas pourquoi, ni dans quel contexte métier précis.

✅ Approche orientée événements :

class CommandePayee {
CommandeId commandeId;
Money montant;
LocalDateTime datePaiement;
}

Cet événement exprime explicitement un fait métier :

“La commande a été payée.”

Utilisation dans le modèle

Lorsqu’une action métier importante se produit :

commande.confirmerPaiement();

l’agrégat peut émettre un événement :

events.add(new CommandePayee(commande.id(), montant, now));

Cet événement peut ensuite être utilisé pour :

déclencher des notifications ;
mettre à jour d’autres agrégats ;
alimenter des systèmes externes ;
construire des projections (read models).
Exemple en système distribué

Dans une architecture distribuée :

chaque nœud reçoit des événements ;
il met à jour son modèle local ;
il n’a pas besoin de connaître l’état global complet.

Ainsi :

l’état est une conséquence des événements, pas une source unique de vérité.

Identité et déduplication

Les événements peuvent contenir une identité dérivée de leurs attributs :

type d’événement ;
identifiants des entités ;
timestamp ;
paramètres métier.

Cela permet de reconnaître deux événements identiques arrivant sur différents nœuds et d’éviter les doublons.

Nature des événements de domaine
immutables : ils ne changent jamais ;
significatifs : ils représentent un fait métier ;
traçables : ils permettent de comprendre le passé du système ;
composables : ils servent de base à d’autres modèles (projections, workflows, intégrations).
Différence clé avec les logs
Logs techniques Événements de domaine
Orientés système    Orientés métier
Debug / monitoring  Modélisation du domaine
Non structurés métier   Porteurs de sens métier
Secondaires Partie du modèle
Idée centrale

Un événement de domaine répond à une question simple :

“Qu’est-ce qui s’est passé dans le domaine ?”

et non :

“Qu’est-ce que le système a fait ?”

En DDD, les événements de domaine permettent de rendre explicite ce qui est souvent implicite dans les systèmes traditionnels : la signification des changements.

## Fabriques (Factories)

Lorsque la création d’un agrégat complet et cohérent, ou d’un objet-valeur complexe, devient compliquée ou expose trop de détails internes, les fabriques fournissent un mécanisme d’encapsulation.

La création d’un objet peut constituer une opération importante à part entière. Cependant, les opérations complexes d’assemblage ne relèvent généralement pas de la responsabilité des objets créés eux-mêmes. Mélanger ces responsabilités conduit souvent à des conceptions lourdes et difficiles à comprendre.

À l’inverse, laisser le client construire directement les objets :

complique la conception du client ;
viole l’encapsulation de l’objet ou de l’agrégat ;
crée un fort couplage entre le client et les détails d’implémentation des objets créés.

Par conséquent :

Transférez la responsabilité de la création des objets complexes et des agrégats vers un objet distinct appelé Factory (Fabrique).

Cette fabrique peut ne pas avoir de responsabilité métier propre dans le modèle de domaine, tout en restant un élément important de la conception du domaine.

Exposez une interface qui :

encapsule toute la logique complexe de construction ;
évite au client de dépendre des classes concrètes des objets instanciés.

Créez un agrégat complet en une seule opération, tout en garantissant le respect de ses invariants.

Créez également les objets-valeurs complexes comme des unités cohérentes, éventuellement après avoir assemblé leurs composants à l’aide d’un Builder.

Exemple (DDD)

Imaginons un agrégat Commande.

Sans Factory :

Client client = clientRepository.trouver(clientId);

AdresseLivraison adresse =
new AdresseLivraison(...);

List<LigneCommande> lignes =
construireLignes(panier);

Commande commande =
new Commande(
UUID.randomUUID(),
client,
lignes,
adresse,
LocalDateTime.now()
);

Le client connaît trop de détails :

structure interne de Commande ;
objets nécessaires à sa création ;
règles d'initialisation ;
invariants métier.

Avec une Factory :

Commande commande =
commandeFactory.creerCommande(
clientId,
panier,
adresseLivraison
);

La logique de création est centralisée :

public class CommandeFactory {

    public Commande creerCommande(
            ClientId clientId,
            Panier panier,
            AdresseLivraison adresse) {

        Client client =
            clientRepository.trouver(clientId);

        List<LigneCommande> lignes =
            LigneCommandeAssembler.depuis(panier);

        return new Commande(
            CommandeId.nouveau(),
            client,
            lignes,
            adresse
        );
    }
}

Factory et invariants métier

Un des rôles essentiels de la Factory est de garantir qu'un objet ne puisse jamais être créé dans un état invalide.

Par exemple :

❌ Interdit :

Commande commande =
new Commande(
client,
Collections.emptyList()
);

Une commande sans ligne de commande viole une règle métier.

✅ La Factory vérifie cette règle :

public Commande creerCommande(
Client client,
List<LigneCommande> lignes) {

    if (lignes.isEmpty()) {
        throw new CommandeInvalideException();
    }

    return new Commande(client, lignes);
}

Ainsi, toute instance créée est valide dès sa naissance.

Différence entre Factory et Repository
Factory Repository
Crée les agrégats   Retrouve et persiste les agrégats
Responsable de l'assemblage Responsable du stockage
Garantit les invariants à la création   Garantit l'accès aux agrégats
Utilisée lors de l'instanciation    Utilisée après l'instanciation

En DDD, on résume souvent leur rôle ainsi :

Factory → "Créer"
Repository → "Retrouver"

Les deux travaillent généralement ensemble :

Commande commande =
commandeFactory.creerCommande(...);

commandeRepository.sauvegarder(commande);

La Factory produit un agrégat valide ; le Repository le conserve et permet de le retrouver ultérieurement.

# Conception souple (Supple Design)

Pour qu’un projet gagne en vitesse au fil de son développement — au lieu d’être ralenti par le poids de son propre héritage — il faut une conception agréable à utiliser et qui accueille facilement le changement. C’est ce qu’on appelle une conception souple (Supple Design).

La conception souple est le complément naturel de la modélisation profonde (Deep Modeling).

Les développeurs jouent deux rôles distincts, et la conception doit répondre aux besoins de chacun. Une même personne peut d’ailleurs alterner entre ces rôles plusieurs fois dans la même journée, mais sa relation au code n’est pas la même dans chaque cas.

### 1. Le développeur client du modèle

Le premier rôle est celui du développeur qui utilise les objets du domaine pour construire des fonctionnalités applicatives ou d’autres parties de la couche métier.

Une conception souple révèle un modèle sous-jacent profond et rend clairement visibles les possibilités offertes par ce modèle.

Le développeur peut alors :

utiliser un nombre réduit de concepts ;
travailler avec des éléments faiblement couplés ;
exprimer facilement de nombreux scénarios métier ;
composer les éléments du modèle de manière naturelle.

Le résultat est une conception :

prévisible ;
cohérente ;
robuste ;
facile à exploiter.

### 2. Le développeur qui fait évoluer le modèle

La conception doit également servir le développeur chargé de la faire évoluer.

Pour être ouverte au changement, une conception doit :

être facile à comprendre ;
exposer clairement le modèle métier sous-jacent ;
suivre fidèlement la structure du domaine ;
permettre aux modifications de s'effectuer sur des points naturellement flexibles.

Les effets du code doivent être immédiatement compréhensibles afin que les conséquences d'une modification puissent être anticipées sans difficulté.

Lorsque ces qualités sont présentes, le système devient plus simple à faire évoluer, même après plusieurs années.

## Les objectifs d'une conception souple

Eric Evans résume les bénéfices d'une conception souple autour de trois idées fondamentales :

### 1. Rendre le comportement évident (Making behavior obvious)

Le comportement du système doit être facile à comprendre simplement en lisant le code.

Exemple :

commande.annuler();

est plus explicite que :

commande.setStatus(Status.CANCELLED);

La première version exprime une intention métier ; la seconde ne révèle qu'une modification technique d'état.

### 2. Réduire le coût du changement (Reducing the cost of change)

Les modifications doivent pouvoir être réalisées avec un impact limité sur le reste du système.

Une bonne conception :

minimise les dépendances ;
protège les invariants ;
isole les responsabilités.

Ainsi, une évolution métier importante n'entraîne pas une cascade de modifications imprévisibles.

### 3. Créer un logiciel agréable à développer (Creating software developers want to work with)

Un système bien conçu est un système dans lequel les développeurs aiment travailler.

Ses caractéristiques sont généralement :

un langage métier clair ;
des abstractions naturelles ;
peu de complexité accidentelle ;
des responsabilités bien réparties ;
un modèle qui reflète réellement le domaine.

Dans un tel environnement, les développeurs passent davantage de temps à résoudre des problèmes métier qu'à lutter contre la structure du code.

Interfaces révélatrices d’intention (Intention-Revealing Interfaces)

Si un développeur doit examiner l’implémentation interne d’un composant pour pouvoir l’utiliser correctement, alors la valeur de l’encapsulation est perdue.

De même, si une personne autre que le développeur d’origine doit déduire l’objectif d’un objet ou d’une opération à partir de son implémentation, elle risque d’interpréter sa finalité de manière erronée. L’opération ou la classe peut sembler remplir un rôle particulier simplement par hasard. Si cette interprétation n’était pas l’intention initiale, le code peut continuer à fonctionner temporairement, mais les fondements conceptuels de la conception seront progressivement corrompus. Les développeurs finiront alors par travailler avec des compréhensions différentes du même modèle.

Par conséquent :

Nommez les classes et les opérations de manière à décrire clairement :

leur objectif ;
leur effet métier ;

sans faire référence aux moyens techniques utilisés pour atteindre ce résultat.

Cette approche évite au développeur client d'avoir à comprendre les détails internes de l'implémentation.

Les noms choisis doivent être conformes au langage omniprésent (Ubiquitous Language) afin que tous les membres de l'équipe puissent en comprendre rapidement le sens.

Enfin, écrivez un test décrivant le comportement attendu avant de créer l'implémentation. Cela vous oblige à réfléchir comme un utilisateur de l'interface plutôt que comme son implémenteur.

Exemple : interface non révélatrice d'intention
client.setFlag(true);

Que signifie ce flag ?

Client premium ?
Client actif ?
Client vérifié ?
Client suspendu ?

L'intention métier est totalement cachée.

Exemple : interface révélatrice d'intention
client.activerCompte();

ou

client.marquerCommeClientPremium();

L'action métier est immédiatement compréhensible.

Exemple avec un agrégat Commande

❌ Orienté implémentation :

commande.setStatus(Status.PAID);

Le lecteur doit connaître :

les valeurs possibles du statut ;
les règles métier associées ;
les conséquences de cette transition.

✅ Orienté intention :

commande.confirmerPaiement();

Le nom exprime directement le concept métier.

L'agrégat peut ensuite :

vérifier les invariants ;
enregistrer un événement métier ;
mettre à jour son état interne ;

sans exposer ces détails à ses utilisateurs.

Exemple avec un Repository

❌ Technique :

commandeRepository.findByStatusAndDate(
Status.PENDING,
date
);

✅ Métier :

commandeRepository.trouverCommandesEnRetard();

ou

commandeRepository.trouverCommandesEnAttenteDePaiement();

La méthode reflète un concept du domaine plutôt qu'un critère de stockage.

Exemple avec un test

Eric Evans recommande implicitement une approche proche du Test-Driven Development (TDD) :

Avant d'écrire :

commande.confirmerPaiement();

on écrit :

@Test
void uneCommandePayeeDevientValidee() {
commande.confirmerPaiement();

    assertTrue(
        commande.estPayee()
    );
}

Le test est rédigé du point de vue du client de l'API. Il oblige à concevoir une interface compréhensible avant même de penser à l'implémentation.

Bénéfices

Les interfaces révélatrices d’intention permettent de :

rendre le code auto-explicatif ;
réduire le besoin de documentation technique ;
renforcer le langage omniprésent ;
protéger l'encapsulation ;
diminuer le coût des changements ;
améliorer la lisibilité des tests ;
faciliter l'intégration de nouveaux développeurs.

En DDD, une bonne interface répond souvent à cette question :

« Un expert métier comprendrait-il approximativement ce que fait cette méthode simplement en lisant son nom ? »

Si la réponse est oui, l'interface révèle probablement correctement son intention.

Fonctions sans effet de bord (Side-Effect-Free Functions)

Lorsque plusieurs règles métier interagissent ou que plusieurs calculs sont composés entre eux, il devient extrêmement difficile de prévoir le résultat obtenu.

Le développeur qui appelle une opération doit alors comprendre non seulement son implémentation, mais également celle de toutes les opérations qu’elle délègue, afin d’anticiper son comportement. Dans ce contexte, l’abstraction offerte par les interfaces perd une grande partie de sa valeur, puisque les développeurs sont contraints de regarder derrière le rideau de l’implémentation.

Sans abstractions fiables et prévisibles, les développeurs doivent limiter la complexité des combinaisons possibles, ce qui réduit considérablement la richesse du comportement qu’un système peut raisonnablement prendre en charge.

Par conséquent :

Placez autant que possible la logique du programme dans des fonctions sans effet de bord (Side-Effect-Free Functions), c’est-à-dire dans des opérations qui produisent un résultat sans modifier d’état observable.

Séparez strictement :

les commandes (Commands), qui modifient l’état du système ;
les requêtes (Queries), qui calculent ou retournent des informations.

Les commandes doivent rester très simples et ne pas retourner d’informations métier complexes.

Pour mieux maîtriser les effets de bord, déplacez la logique complexe vers des objets-valeurs lorsqu’un concept métier approprié s’y prête.

Toutes les opérations exposées par un objet-valeur devraient être des fonctions sans effet de bord.

Qu'est-ce qu'un effet de bord ?

Une opération possède un effet de bord lorsqu'elle modifie quelque chose d'observable en dehors de son résultat.

Par exemple :

compte.debiter(100);

Cette méthode modifie l'état du compte.

Elle possède donc un effet de bord.

À l'inverse :

Money frais = calculateur.calculerFrais(montant);

Cette méthode se contente de calculer une valeur et de la retourner.

Elle n'altère aucun état observable.

C'est une fonction sans effet de bord.

Exemple simple

❌ Fonction avec effet de bord :

public Money calculerRemise(Client client) {

    client.incrementerCompteurCalculs();

    return ...
}

Le simple calcul modifie l'état du client.

Le comportement est difficile à anticiper.

✅ Fonction sans effet de bord :

public Money calculerRemise(Client client) {

    return ...
}

Le résultat dépend uniquement des paramètres.

Aucun état n'est modifié.

## Séparation Command / Query

Ce principe est très proche du Command Query Separation (CQS) de Bertrand Meyer.

Une méthode devrait :

soit modifier l'état ;
soit retourner une information ;
mais rarement faire les deux.

❌ Exemple ambigu :

public Money debiter(Money montant) {

    solde = solde.minus(montant);

    return solde;
}

La méthode modifie l'état et retourne une information.

✅ Exemple plus explicite :

public void debiter(Money montant) {
solde = solde.minus(montant);
}

et

public Money obtenirSolde() {
return solde;
}

Les responsabilités sont clairement séparées.

Exemple avec un objet-valeur

Considérons un objet-valeur représentant une somme d'argent :

public final class Money {

    private final BigDecimal montant;

    public Money ajouter(Money autre) {
        return new Money(
            montant.add(autre.montant)
        );
    }
}

Utilisation :

Money total =
prix.ajouter(taxe);

L'objet original n'est jamais modifié.

Chaque opération retourne une nouvelle valeur.

Cette approche :

évite les effets de bord ;
simplifie les tests ;
améliore la prévisibilité ;
favorise l'immuabilité.
Pourquoi Eric Evans insiste sur les objets-valeurs ?

Les objets-valeurs sont naturellement adaptés aux fonctions sans effet de bord car :

ils sont immuables ;
ils n'ont pas d'identité ;
leur rôle principal est de représenter une valeur ou un calcul.

Par exemple :

Montant
Pourcentage
Adresse
Période
Distance
Coordonnée géographique

sont souvent d'excellents candidats pour porter de la logique pure.

Bénéfices

Les fonctions sans effet de bord permettent :

un comportement plus prévisible ;
une meilleure lisibilité ;
des tests plus simples ;
moins de bugs liés aux états partagés ;
une meilleure composition des règles métier ;
une plus grande flexibilité dans l'évolution du modèle.

Dans l'esprit du DDD, elles contribuent directement au Supple Design en rendant le comportement du système plus évident et en réduisant le coût des changements.

Une règle pratique est souvent :

Plus une opération est complexe, plus elle devrait tendre vers une fonction pure et sans effet de bord.

Cela permet au modèle de rester expressif tout en conservant un comportement facile à comprendre et à faire évoluer.

Assertions (Assertions)

Lorsque les effets de bord des opérations ne sont définis qu’implicitement par leur implémentation, les conceptions fortement déléguées deviennent un enchevêtrement de causes et d’effets. La seule manière de comprendre un programme consiste alors à suivre son exécution à travers ses différents chemins d’exécution.

Dans ce contexte, la valeur de l’encapsulation est affaiblie. La nécessité de « suivre le code pas à pas » détruit le niveau d’abstraction attendu d’un bon modèle.

Par conséquent :

Exprimez explicitement les postconditions des opérations ainsi que les invariants des classes et des agrégats.

Si le langage de programmation ne permet pas d’exprimer directement ces assertions, écrivez-les sous forme de tests unitaires automatisés. Vous pouvez également les documenter dans le code ou dans des diagrammes, selon le style et le processus de développement du projet.

Recherchez des modèles composés de concepts cohérents, qui permettent au développeur de déduire naturellement les assertions attendues. Cela accélère la compréhension du système et réduit le risque d’incohérences dans le code.

## Classes autonomes (Standalone Classes)

Même au sein d’un module, la difficulté d’interpréter une conception augmente fortement à mesure que les dépendances se multiplient. Cela accroît la charge mentale et limite la complexité qu’un développeur peut gérer efficacement. Les concepts implicites contribuent encore davantage à cette surcharge que les références explicites.

Le faible couplage (low coupling) est un principe fondamental de la conception objet. Lorsque cela est possible, il faut aller encore plus loin : éliminer autant que possible les autres concepts nécessaires à la compréhension d’une classe. Dans ce cas, la classe devient entièrement autonome et peut être étudiée et comprise isolément.

Chaque classe véritablement autonome réduit de manière significative la difficulté globale de compréhension d’un module.

Principe

Une classe autonome est une classe qui :

dépend de très peu d’autres concepts ;
exprime clairement son propre modèle interne ;
peut être comprise sans naviguer dans tout le système ;
minimise les interactions implicites.
Pourquoi c’est important

Quand une classe dépend de nombreuses autres abstractions :

il devient difficile de prédire son comportement ;
la compréhension nécessite de naviguer dans plusieurs fichiers ;
les modifications deviennent risquées ;
la complexité globale augmente de manière exponentielle.

À l’inverse, une classe autonome :

réduit la charge cognitive ;
facilite la lecture locale du code ;
rend les changements plus sûrs ;
améliore la testabilité.
Exemple : classe fortement couplée
class FacturationService {

    private ClientRepository clientRepository;
    private TaxService taxService;
    private PricingService pricingService;
    private DiscountPolicy discountPolicy;

    public Facture genererFacture(Commande commande) {
        // logique répartie sur plusieurs dépendances
    }
}

Pour comprendre cette classe, il faut comprendre :

le client ;
les taxes ;
les prix ;
les remises ;
les règles métier externes.

La classe ne peut pas être étudiée isolément.

Exemple : classe plus autonome
class Money {

    private final BigDecimal amount;

    public Money add(Money other) {
        return new Money(amount.add(other.amount));
    }

    public Money multiply(BigDecimal factor) {
        return new Money(amount.multiply(factor));
    }
}

Ici :

aucune dépendance externe ;
comportement entièrement local ;
compréhension immédiate ;
test facile.
Exemple intermédiaire (DDD)

Un objet-valeur autonome :

class Periode {

    private final LocalDate debut;
    private final LocalDate fin;

    public boolean chevauche(Periode autre) {
        return !fin.isBefore(autre.debut)
            && !debut.isAfter(autre.fin);
    }
}

Cette classe :

encapsule son propre concept ;
n’a pas besoin d’autres services ;
exprime un invariant métier clair ;
peut être comprise seule.
Lien avec le DDD

Les classes autonomes sont particulièrement importantes pour :

les objets-valeurs (idéaux candidats) ;
certaines entités simples ;
les services de domaine très focalisés.

En revanche, les agrégats et les services complexes sont naturellement plus connectés — mais même dans ces cas, chaque classe interne devrait viser une autonomie maximale.

Idée clé

Une bonne question à se poser :

Puis-je comprendre cette classe sans ouvrir d’autre fichier ?

Si la réponse est non, la conception dépend probablement trop du contexte global.

Une classe autonome ne signifie pas une classe isolée du système, mais une classe dont le sens est localement compréhensible.

## Clôture des opérations (Closure of Operations)

La plupart des objets intéressants finissent par effectuer des opérations qui ne peuvent pas être décrites uniquement à l’aide de primitives.

Par conséquent :

Lorsque cela est pertinent, définissez une opération dont le type de retour est identique au type de ses arguments. Si l’implémentation dépend d’un état interne, alors l’objet qui porte cet état peut être vu comme un argument implicite de l’opération.

Ainsi, les arguments et la valeur de retour appartiennent au même type que l’objet lui-même.

Une telle opération est dite fermée (closed) sur l’ensemble des instances de ce type.

Une opération fermée fournit une interface de haut niveau sans introduire de dépendances vers d’autres concepts du modèle.

Pourquoi la clôture est importante

Une opération fermée :

maintient le raisonnement à l’intérieur d’un seul concept ;
évite de « sortir » du modèle pour obtenir une réponse ;
réduit les dépendances entre concepts ;
simplifie la composition des comportements.

Elle permet de rester dans un espace conceptuel unique.

Exemple typique : objets-valeurs

Les objets-valeurs sont les meilleurs candidats pour ce pattern, car ils sont :

immuables ;
sans identité ;
centrés sur des transformations de valeur.
Exemple : Money
Money a = new Money(100);
Money b = new Money(50);

Money result = a.add(b);

Ici :

entrée : Money
sortie : Money
l’opération est fermée sur le type Money

Aucune dépendance externe n’est introduite.

Exemple : Intervalle de temps
Periode p1 = new Periode(jan1, jan10);
Periode p2 = new Periode(jan5, jan15);

Periode fusion = p1.fusionner(p2);

On reste dans le même concept :

Periode → Periode
Avantage clé

Une opération fermée permet de :

rester dans un raisonnement homogène ;
éviter les conversions conceptuelles inutiles ;
composer facilement les opérations ;
limiter la dépendance à d’autres couches du système.
Cas des entités

Les entités sont moins adaptées à la clôture complète, car :

elles ont une identité ;
leur cycle de vie est important ;
elles ne sont pas toujours « recombinables ».

Cependant, certaines opérations restent fermées :

Employee superviseur = employee.superviseur();
Employee → Employee

Mais on ne “crée” pas librement des entités pour calculer un résultat métier.

Cas intermédiaires

Certaines opérations sont partiellement fermées :

Money taxe = calculator.calculerTaxe(Money montant);
argument : Money
retour : Money
mais dépend d’un service externe

Ce n’est pas une fermeture stricte, mais on conserve une cohérence conceptuelle partielle, ce qui aide déjà à réduire la charge mentale.

Ce que la clôture apporte vraiment

Même quand elle n’est pas parfaite, la fermeture :

réduit la fragmentation conceptuelle ;
rend le code plus prévisible ;
améliore la composition des règles métier ;
renforce le langage omniprésent.
Idée centrale

Une bonne opération fermée permet de rester dans le même concept sans « changer de monde mental ».

On entre dans un type de concept… et on en ressort avec le même type de concept.

C’est cette continuité qui rend les modèles plus expressifs et plus faciles à raisonner.

## Contours conceptuels (Conceptual Contours)

Parfois, on découpe les fonctionnalités très finement pour permettre des combinaisons flexibles. Parfois, au contraire, on regroupe fortement afin d’encapsuler la complexité. Parfois encore, on cherche une granularité uniforme, en faisant en sorte que toutes les classes et opérations aient une taille similaire. Ces approches sont des simplifications excessives qui ne fonctionnent pas comme règles générales, mais elles répondent à des problèmes réels.

Lorsque les éléments d’un modèle ou d’une conception sont enfermés dans une structure monolithique, leurs fonctionnalités tendent à être dupliquées. L’interface externe ne reflète pas tout ce qui pourrait être important pour un client. Le sens devient difficile à comprendre, car plusieurs concepts sont mélangés.

À l’inverse, une décomposition excessive des classes et des méthodes peut compliquer inutilement l’utilisation du système, en obligeant les clients à comprendre comment de petites pièces s’assemblent entre elles. Pire encore, un concept peut disparaître complètement : la moitié d’un atome d’uranium n’est plus de l’uranium. Et bien sûr, ce n’est pas seulement la taille des morceaux qui compte, mais aussi la manière dont les découpes traversent les concepts.

Par conséquent :

Décomposez les éléments de conception (opérations, interfaces, classes et agrégats) en unités cohérentes, en vous appuyant sur votre compréhension des divisions importantes du domaine.

Observez les axes de changement et de stabilité au fil des refactorings successifs, et cherchez les contours conceptuels sous-jacents qui expliquent ces lignes de fracture.

Alignez le modèle avec les aspects stables et structurants du domaine — ceux qui en font un véritable objet de connaissance.

Pourquoi les contours conceptuels sont importants

Le problème n’est pas la taille des éléments, mais la manière dont ils découpent le sens.

Une bonne découpe :

respecte les concepts du domaine ;
minimise les ruptures artificielles ;
rend les interfaces naturelles à utiliser ;
évite les duplications de logique.

Une mauvaise découpe :

mélange plusieurs concepts dans une même abstraction ;
fragmente un concept unique en morceaux incompréhensibles ;
oblige le client à reconstruire mentalement le domaine ;
multiplie les chemins d’accès à une même logique.
Exemple : mauvaise décomposition (trop fine ou incohérente)
calculerPrix()
calculerTaxe()
appliquerRemise()
assemblerFacture()

Chaque opération est isolée, mais le concept métier « facturation » est dispersé.

Le client doit comprendre l’ordre, les dépendances, et les règles implicites.

Exemple : sur-agrégation (monolithique)
FacturationService.genererTout(
client,
panier,
promotions,
taxes,
optionsLivraison
);

Tout est centralisé, mais :

l’interface est opaque ;
les concepts métier sont mélangés ;
l’extensibilité est réduite.
Exemple : découpe selon contours conceptuels
Facture facture = factureFactory.creerDepuis(panier);

facture.appliquerPromotions();

facture.calculerTaxes();

facture.valider();

Ici :

chaque étape correspond à un concept métier clair ;
les responsabilités sont cohérentes ;
les opérations sont composables ;
le langage reste lisible.
Comment trouver les bons contours

Les bons contours ne viennent pas d’une règle mécanique, mais de l’observation :

Qu’est-ce qui change ensemble ?
Qu’est-ce qui reste stable ?
Quels concepts les experts métier distinguent-ils naturellement ?
Où les modifications du code se concentrent-elles ?

Les refactorings successifs révèlent souvent des « lignes de fracture naturelles » dans le modèle.

Lien avec le DDD

Les contours conceptuels sont ce qui permet :

des agrégats cohérents ;
des services bien ciblés ;
des objets-valeurs naturels ;
un langage omniprésent fluide ;
une conception souple (supple design).

Ils sont, en pratique, ce qui empêche le modèle de devenir :

soit trop fragmenté ;
soit trop monolithique.
Idée centrale

Un bon modèle ne dépend pas de la taille de ses pièces, mais de la manière dont ces pièces épousent les concepts du domaine.

Le but n’est pas de découper finement ou grossièrement, mais de découper juste.

C’est cette justesse des contours qui rend le modèle lisible, stable et évolutif.