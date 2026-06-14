### Définitions

**Domaine (Domain)**
Une sphère de connaissance, d’influence ou d’activité. Le domaine d’un logiciel correspond au sujet ou à l’activité sur lequel l’utilisateur applique ce logiciel.

**Modèle (Model)**
Un système d’abstractions qui décrit certains aspects sélectionnés d’un domaine et qui peut être utilisé pour résoudre des problèmes liés à ce domaine.

**Langage ubiquitaire (Ubiquitous Language)**
Un langage structuré autour du modèle de domaine et utilisé par tous les membres de l’équipe au sein d’un Bounded Context. Il permet de relier l’ensemble des activités de l’équipe au logiciel et d’assurer une compréhension commune du domaine.

**Contexte (Context)**
L’environnement dans lequel un mot ou une affirmation apparaît et qui en détermine le sens. Les énoncés relatifs à un modèle ne peuvent être compris qu’à l’intérieur d’un contexte donné.

**Contexte délimité (Bounded Context)**
La description d’une frontière (généralement un sous-système ou le périmètre de responsabilité d’une équipe) à l’intérieur de laquelle un modèle particulier est défini, partagé et applicable.

### Mettre le modèle au service du développement

Le **Domain-Driven Design (DDD)** est une approche de développement des logiciels complexes dans laquelle nous :

1. **Concentrons nos efforts sur le cœur du domaine métier (Core Domain)**.
2. **Explorons les modèles** au travers d’une collaboration créative entre les experts métier et les professionnels du développement logiciel.
3. **Utilisons un langage ubiquitaire** au sein d’un **Bounded Context explicitement défini**.

Cette synthèse en trois points du DDD repose sur les définitions des concepts fondamentaux présentés dans ce document.

De nombreux projets réalisent des activités de modélisation sans en retirer de bénéfices significatifs. Les patterns du Domain-Driven Design sont issus de l’observation et de la formalisation de pratiques ayant démontré leur efficacité dans des projets où la modélisation a produit des résultats remarquables.

Pris dans leur ensemble, ces patterns proposent une approche du développement logiciel sensiblement différente des méthodes traditionnelles. Ils couvrent un large spectre, allant des détails d’implémentation les plus fins jusqu’à la vision stratégique du système et de l’organisation.

Les conventions rigoureuses de modélisation doivent être équilibrées par une exploration libre et créative des modèles, menée en collaboration avec les experts métier et les parties prenantes non techniques. De même, les considérations tactiques et stratégiques doivent être combinées pour réussir.

C’est pourquoi le Domain-Driven Design s’intéresse simultanément :

- **au design tactique**, qui concerne la conception du code et des modèles à l’intérieur des Bounded Contexts (Entités, Objets Valeur, Agrégats, Services de Domaine, Événements de Domaine, etc.) ;
- **au design stratégique**, qui traite du découpage du système, de la définition des Bounded Contexts, de leurs relations et de l’organisation des équipes.

### Lecture moderne de cette définition

Cette présentation met en évidence que le DDD n’est ni une méthode de modélisation, ni un ensemble de patterns techniques. Il constitue avant tout une **approche de résolution de problèmes complexes centrée sur le métier**.

Les trois piliers présentés par Eric Evans sont profondément liés :

- **Le Core Domain** donne la direction et permet de concentrer les investissements là où l’entreprise crée le plus de valeur.
- **La modélisation collaborative** permet de construire une compréhension partagée du problème et de faire émerger des modèles pertinents.
- **Le Langage Ubiquitaire et les Bounded Contexts** garantissent que cette compréhension reste cohérente dans le temps, aussi bien dans les conversations que dans le code.

Ainsi, le DDD ne cherche pas uniquement à produire un meilleur logiciel. Il vise à aligner durablement **la compréhension métier, les équipes, les modèles et l’architecture**, afin que le système puisse évoluer sans perdre son sens ni sa cohérence.

### Contexte Délimité (Bounded Context)

Dans tout projet d’envergure, plusieurs modèles coexistent inévitablement. Ils émergent pour de nombreuses raisons. Deux sous-systèmes servent souvent des communautés d’utilisateurs très différentes, exerçant des métiers distincts, pour lesquelles des modèles différents sont plus pertinents. Des équipes travaillant de manière indépendante peuvent également résoudre un même problème de façons différentes en raison d’un manque de communication. Enfin, les outils et technologies employés peuvent varier, rendant impossible le partage direct du code.

La coexistence de plusieurs modèles est donc inévitable. Cependant, lorsque du code fondé sur des modèles distincts est mélangé, le logiciel devient source de défauts, moins fiable et plus difficile à comprendre. La communication entre les membres de l’équipe se dégrade également, car il devient difficile de savoir dans quel contexte un modèle donné doit ou ne doit pas être appliqué.

Comme toute expression linguistique, les concepts d’un modèle n’ont de sens qu’à l’intérieur d’un contexte précis.

**Par conséquent :**

Définissez explicitement le contexte dans lequel un modèle s’applique. Établissez clairement ses frontières en tenant compte :

- de l’organisation des équipes ;
- de son utilisation dans certaines parties spécifiques de l’application ;
- de ses manifestations physiques, telles que les bases de code ou les schémas de bases de données.

À l’intérieur de ces frontières, appliquez l’**Intégration Continue (Continuous Integration)** afin de maintenir une cohérence stricte des concepts et du vocabulaire du modèle. En revanche, évitez d’être distrait ou perturbé par les problématiques situées en dehors de ce périmètre.

Enfin, standardisez un processus de développement unique à l’intérieur du contexte délimité, sans pour autant imposer ce même processus aux autres contextes.

### Interprétation en DDD

Cette définition met en évidence une idée fondamentale du Domain-Driven Design : **un modèle n’est jamais universel**. Sa validité est limitée à un espace de cohérence donné, appelé *Bounded Context*. À l’intérieur de ce périmètre :

- le langage ubiquitaire possède une signification unique ;
- les concepts métier sont cohérents ;
- les équipes partagent la même compréhension du domaine ;
- le code, les bases de données et les pratiques de développement reflètent ce modèle commun.

Le Bounded Context constitue donc à la fois une **frontière linguistique**, **organisationnelle** et **technique**. Il protège l’intégrité du modèle en empêchant que des concepts issus d’autres contextes viennent brouiller sa cohérence.

Comme le résume Eric Evans, la question essentielle n’est pas de construire un modèle unique pour toute l’entreprise, mais de savoir **où chaque modèle est valide et où il cesse de l’être**. C’est précisément le rôle du Bounded Context.

### Langage Ubiquitaire (Ubiquitous Language)

> *« D’abord, vous écrivez une phrase,
>  Puis vous la découpez en petits morceaux ;
>  Ensuite vous mélangez les fragments et les triez
>  Au gré du hasard ;
>  L’ordre des expressions
>  N’a alors plus aucune importance. »*
>
> — **Lewis Carroll**, *Poeta Fit, Non Nascitur*

Créer un design souple, riche en connaissances et profondément ancré dans le métier exige un langage partagé, suffisamment expressif pour capturer la complexité du domaine. Cela suppose également une expérimentation permanente autour du langage, une pratique qui reste malheureusement rare dans les projets logiciels.

Même au sein d’un unique Bounded Context, le langage peut se fragmenter de multiples façons, compromettant les efforts de modélisation avancée. Si le modèle n’est utilisé que pour produire des diagrammes UML destinés aux membres techniques de l’équipe, il ne contribue plus à la collaboration créative qui constitue pourtant le cœur du Domain-Driven Design.

Les experts métier utilisent leur propre jargon, tandis que les développeurs emploient un vocabulaire façonné par les préoccupations de conception logicielle. Les termes utilisés dans les discussions quotidiennes finissent alors par être déconnectés de ceux qui apparaissent dans le code — alors même que le code représente le principal produit d’un projet logiciel.

Cette fracture est encore accentuée par le fait qu’une même personne utilise souvent un langage différent à l’oral et à l’écrit. Les formulations les plus pertinentes pour décrire le domaine émergent parfois au détour d’une conversation puis disparaissent sans jamais être intégrées ni dans le code ni dans la documentation.

La traduction permanente entre ces différents dialectes affaiblit la communication et appauvrit le processus de découverte de connaissances. Pourtant, aucun de ces langages spécialisés ne peut prétendre devenir le langage commun, car aucun ne répond seul à l’ensemble des besoins.

Les experts métier doivent signaler les termes ou structures qui ne reflètent pas correctement leur compréhension du domaine. De leur côté, les développeurs doivent être attentifs aux ambiguïtés et incohérences susceptibles de fragiliser la conception.

Il faut manipuler le modèle dans les conversations elles-mêmes. Décrivez à voix haute des scénarios métier en utilisant les concepts et les interactions du modèle. Expérimentez de nouvelles formulations, cherchez des expressions plus simples ou plus précises, puis réinjectez ces découvertes dans les diagrammes, la documentation et le code.

Avec un langage ubiquitaire, le modèle cesse d’être un simple artefact de conception. Il devient une composante essentielle de tout ce que les développeurs et les experts métier accomplissent ensemble.

### Par conséquent

Utilisez le modèle comme fondation du langage partagé.

Engagez toute l’équipe à employer ce langage de manière systématique dans toutes les formes de communication ainsi que dans le code. À l’intérieur d’un Bounded Context, utilisez le même vocabulaire dans :

- les conversations ;
- les documents ;
- les diagrammes ;
- les tests ;
- le code.

Reconnaissez qu’un changement de langage est également un changement de modèle.

Lorsque des difficultés apparaissent, expérimentez différentes formulations. Chaque nouvelle expression reflète potentiellement une nouvelle compréhension du domaine et donc un modèle différent. Une fois cette compréhension stabilisée, refactorisez le code en conséquence : renommez les classes, les méthodes, les modules et les concepts afin qu’ils reflètent fidèlement le modèle mis à jour.

Résolvez les ambiguïtés terminologiques dans les conversations de la même manière que nous construisons collectivement le sens des mots dans la langue courante : par le dialogue, l’usage et la recherche d’un consensus partagé.

### Interprétation en DDD

Ce texte contient probablement l'une des idées les plus profondes du Domain-Driven Design : **le langage n'est pas une conséquence du modèle, il est le modèle**.

Dans de nombreuses organisations, les experts métier parlent un langage, les analystes un second, les développeurs un troisième et le code un quatrième. Chaque traduction introduit une perte de sens. Le DDD cherche précisément à supprimer ces couches de traduction.

Le Langage Ubiquitaire devient alors un mécanisme d'alignement entre :

- la compréhension métier ;
- les conversations quotidiennes ;
- les ateliers de modélisation ;
- les tests ;
- l'architecture ;
- le code.

C'est pourquoi Eric Evans affirme qu'une évolution du vocabulaire est un événement majeur : lorsqu'une équipe remplace un terme par un autre, elle ne modifie pas simplement une convention de nommage, elle transforme sa compréhension du domaine.

Pour cette raison, les pratiques modernes telles que l'Event Storming, l'Example Mapping ou le Domain Storytelling accordent une importance particulière aux mots utilisés par les participants. Ces ateliers ne servent pas seulement à découvrir des fonctionnalités ; ils permettent avant tout de faire émerger, tester et stabiliser le Langage Ubiquitaire qui donnera ensuite naissance au modèle et au logiciel.

### Intégration Continue (Continuous Integration)

Une fois qu’un **Bounded Context** a été défini, il est essentiel de préserver son intégrité.

Lorsque plusieurs personnes travaillent au sein d’un même Bounded Context, le modèle a naturellement tendance à se fragmenter. Chaque membre de l’équipe développe progressivement sa propre compréhension du domaine, ce qui peut conduire à des interprétations divergentes des concepts métier.

Plus l’équipe est importante, plus ce risque augmente. Cependant, même une équipe de trois ou quatre personnes peut rencontrer des difficultés significatives. À l’inverse, découper le système en un trop grand nombre de Bounded Contexts afin de limiter cette fragmentation finit par faire perdre un niveau précieux d’intégration et de cohérence globale.

### Par conséquent

Mettez en place un processus permettant de fusionner fréquemment l’ensemble du code et des autres artefacts d’implémentation.

Cette intégration doit être accompagnée de tests automatisés capables de détecter rapidement toute divergence ou fragmentation du modèle.

Parallèlement, utilisez sans relâche le **Langage Ubiquitaire** afin de construire et maintenir une compréhension commune du modèle, alors même que les concepts continuent d’évoluer dans l’esprit de chaque membre de l’équipe.

### Interprétation en DDD

Ce pattern est souvent mal compris. À première vue, il semble simplement promouvoir une pratique d’ingénierie bien connue : l’intégration continue. Pourtant, dans le Domain-Driven Design, son objectif principal n’est pas seulement technique.

Eric Evans cherche avant tout à protéger l’**intégrité du modèle**.

Lorsqu’une équipe travaille sur un même Bounded Context, chaque développeur enrichit progressivement sa propre représentation mentale du domaine. Sans mécanisme de synchronisation régulier, plusieurs versions du modèle émergent silencieusement :

- les mêmes concepts reçoivent des noms différents ;
- des règles métier sont interprétées différemment ;
- des abstractions concurrentes apparaissent ;
- le langage ubiquitaire perd progressivement sa cohérence.

L’intégration continue agit alors comme un mécanisme de convergence. Elle oblige les membres de l’équipe à confronter régulièrement leurs compréhensions respectives du domaine.

Dans l’esprit du DDD, l’intégration continue repose donc sur deux dimensions complémentaires :

#### 1. L’intégration du code

Les équipes fusionnent fréquemment leurs travaux afin de détecter rapidement :

- les conflits de conception ;
- les divergences de modélisation ;
- les incohérences dans le langage du code ;
- les régressions fonctionnelles.

Les tests automatisés servent de filet de sécurité pour révéler ces problèmes au plus tôt.

#### 2. L’intégration du modèle

Dimension souvent oubliée, les équipes doivent également intégrer leurs connaissances du domaine.

Cela passe par :

- les conversations quotidiennes ;
- les revues de code ;
- les ateliers de modélisation ;
- l’Event Storming ;
- l’Example Mapping ;
- les discussions avec les experts métier.

Le Langage Ubiquitaire constitue ici l’outil principal de synchronisation.

### Une lecture moderne

À la lumière des pratiques actuelles, ce pattern dépasse largement le simple pipeline CI/CD.

Une équipe peut disposer d’une excellente chaîne d’intégration technique et pourtant souffrir d’une fragmentation du modèle métier.

Inversement, une équipe qui pratique régulièrement :

- le pair programming ;
- le mob programming ;
- les ateliers de découverte métier ;
- les revues de conception ;
- l’Example Mapping ;
- l’Event Storming ;

réduit considérablement le risque de divergence conceptuelle.

Autrement dit, dans le DDD, **l’intégration continue n’est pas seulement l’intégration du code, c’est l’intégration permanente des connaissances métier dans un modèle partagé**.

C’est précisément cette discipline qui permet à un Bounded Context de conserver sa cohérence malgré l’évolution du logiciel, des équipes et du domaine lui-même.

### Conception Pilotée par le Modèle (Model-Driven Design)

Le fait de relier étroitement le code à un modèle sous-jacent donne du sens au code et rend le modèle lui-même pertinent.

Si la conception du logiciel — ou au moins une partie centrale de celle-ci — ne reflète pas directement le modèle de domaine, alors ce modèle a peu de valeur et la justesse du logiciel devient douteuse. À l’inverse, lorsque les correspondances entre le modèle et l’implémentation sont complexes ou indirectes, elles deviennent difficiles à comprendre et pratiquement impossibles à maintenir à mesure que le système évolue.

Une séparation dangereuse apparaît alors entre l’analyse métier et la conception logicielle : les découvertes réalisées dans l’une de ces activités n’enrichissent plus l’autre.

Le vocabulaire utilisé dans la conception ainsi que la répartition fondamentale des responsabilités doivent être directement issus du modèle. Le code devient alors une expression du modèle. Par conséquent, une modification du code peut constituer une modification du modèle lui-même, dont les effets doivent se répercuter sur l’ensemble des activités du projet.

Cependant, maintenir une correspondance étroite entre le modèle et le logiciel suppose généralement l’utilisation d’outils et de langages qui favorisent une approche de modélisation, comme la programmation orientée objet.

### Par conséquent

Concevez une partie du système logiciel de manière à refléter le modèle de domaine de la façon la plus directe et explicite possible, afin que la correspondance entre les deux soit évidente.

Réexaminez régulièrement le modèle et faites-le évoluer pour qu’il puisse être implémenté plus naturellement dans le logiciel, tout en continuant à approfondir la compréhension du domaine métier.

Exigez l’existence d’un modèle unique capable :

- de représenter fidèlement le métier ;
- d’être implémenté naturellement dans le logiciel ;
- de soutenir un Langage Ubiquitaire fluide et partagé.

### Interprétation en DDD

Ce pattern constitue probablement le cœur philosophique du Domain-Driven Design.

À l’époque où Eric Evans écrit son livre, de nombreuses organisations séparent fortement :

- l’analyse métier ;
- la conception ;
- le développement.

Les analystes produisent des modèles métier, les architectes réalisent des conceptions techniques, puis les développeurs écrivent du code. Chaque étape introduit une traduction supplémentaire, et chaque traduction provoque une perte d’information.

Le Model-Driven Design propose une idée radicalement différente :

> **Le modèle n’est pas un document destiné à être traduit en logiciel. Le modèle est le logiciel.**

Dans une approche DDD mature :

- les concepts du domaine deviennent des classes ;
- les comportements métier deviennent des méthodes ;
- les règles métier deviennent des invariants ;
- les événements métier deviennent des événements de domaine ;
- le langage ubiquitaire devient le langage du code.

Ainsi, lorsqu'un expert métier parle d'une *Réservation*, d'un *Panier* ou d'un *Trade*, ces concepts existent également dans le code sous les mêmes noms et avec les mêmes responsabilités.

### Le véritable enjeu : réduire la distance entre le métier et le code

Le DDD cherche à minimiser la distance qui sépare :

**La réalité métier → Le modèle → Le langage → Le code**

Dans un système bien conçu, ces quatre éléments évoluent ensemble.

À l'inverse, lorsqu'une couche de traduction apparaît entre le modèle et le code, plusieurs symptômes émergent :

- le code devient technique plutôt que métier ;
- les experts métier ne reconnaissent plus leur domaine dans le logiciel ;
- les développeurs doivent continuellement traduire les concepts ;
- les changements métier deviennent coûteux et risqués.

C'est ce que Evans appelle le *deadly divide* : la rupture entre l'analyse et la conception.

### Exemple dans votre contexte de gestion de théâtres

Prenons le cas de la réservation de sièges dans un théâtre.

Dans une approche traditionnelle, on pourrait trouver :

```
SeatManager
SeatCalculator
BookingProcessor
ReservationService
```

Ces noms décrivent davantage des mécanismes techniques que des concepts métier.

Dans une approche de Model-Driven Design, le code reflète directement le modèle :

```
Auditorium
Row
Seat
Reservation
Party
SeatingOffer
```

Les comportements métier sont portés par les objets eux-mêmes :

```
reservation.Confirm();
row.OfferAdjacentSeatsFor(party);
auditorium.FindBestSeatsFor(party);
```

Un expert métier peut alors reconnaître immédiatement les concepts qu'il manipule quotidiennement.

### Une lecture moderne

Aujourd'hui, ce pattern reste l'un des plus différenciants du DDD.

Il explique pourquoi les équipes qui pratiquent :

- l'Event Storming ;
- l'Example Mapping ;
- le Domain Storytelling ;
- la modélisation collaborative ;

obtiennent souvent de meilleurs résultats que celles qui se concentrent uniquement sur l'architecture technique.

Ces ateliers ne visent pas principalement à produire des diagrammes. Ils servent à découvrir un modèle suffisamment pertinent pour que le code puisse devenir son expression directe.

En définitive, le **Model-Driven Design** affirme qu'un logiciel de qualité n'est pas seulement un programme qui fonctionne. C'est un programme dont la structure révèle explicitement la compréhension que l'équipe possède du domaine métier. Lorsque le modèle évolue, le code évolue avec lui ; lorsque le code évolue, il enrichit à son tour la compréhension du modèle. C'est cette boucle de rétroaction permanente qui constitue l'essence même du Domain-Driven Design.

### Modélisateurs impliqués dans l’implémentation (Hands-on Modelers)

Si les personnes qui écrivent le code ne se sentent pas responsables du modèle, ou ne comprennent pas comment faire vivre ce modèle dans une application, alors le modèle n’a plus aucun lien réel avec le logiciel.

De même, si les développeurs ne réalisent pas que modifier le code revient également à modifier le modèle, leurs activités de refactoring risquent d’affaiblir le modèle plutôt que de le renforcer.

À l’inverse, lorsqu’un modélisateur est tenu à l’écart de l’implémentation, il ne développe jamais — ou perd rapidement — la compréhension des contraintes concrètes du développement logiciel. L’exigence fondamentale du **Model-Driven Design**, qui consiste à construire un modèle à la fois représentatif du domaine et naturellement implémentable, disparaît alors progressivement. Les modèles produits deviennent théoriquement séduisants mais pratiquement inutilisables.

Enfin, lorsque les responsabilités sont cloisonnées de manière excessive, les connaissances et les compétences des concepteurs expérimentés ne se transmettent plus aux autres développeurs. La collaboration quotidienne, indispensable pour partager les subtilités de la conception pilotée par le modèle, disparaît.

### Par conséquent

Toute personne technique qui contribue au modèle doit également passer du temps au contact du code, quel que soit son rôle principal dans le projet.

Inversement, toute personne qui modifie le code doit apprendre à exprimer le modèle à travers celui-ci.

Chaque développeur doit :

- participer, à un certain niveau, aux discussions relatives au modèle ;
- être exposé aux problématiques métier ;
- avoir des interactions régulières avec les experts du domaine.

Les personnes contribuant au projet sous des angles différents doivent s’engager consciemment dans un échange permanent autour du modèle, en utilisant le Langage Ubiquitaire comme support de communication.

------

## Interprétation en DDD

Ce pattern est avant tout une critique des organisations fondées sur une séparation stricte des rôles.

À l'époque d'Eric Evans, il était fréquent de rencontrer une organisation de ce type :

```
Experts métier
        ↓
Analystes
        ↓
Architectes
        ↓
Développeurs
```

Chaque niveau traduisait les informations reçues du niveau précédent.

Le problème est que chaque traduction introduit une perte de sens. À l'arrivée, les développeurs implémentent souvent des concepts qu'ils ne comprennent qu'imparfaitement, tandis que les experts métier ne reconnaissent plus leur propre domaine dans le logiciel.

Le DDD propose au contraire de réduire au maximum cette distance.

------

## Le développeur est aussi un modélisateur

Dans une démarche DDD, un développeur n'est pas simplement un programmeur chargé de transformer des spécifications en code.

Il participe activement à :

- la découverte du domaine ;
- la construction du modèle ;
- l'amélioration du langage ubiquitaire ;
- l'évolution des concepts métier.

Le code n'est pas considéré comme une étape terminale du processus. Il constitue l'un des principaux outils de validation du modèle.

Un concept difficile à implémenter révèle souvent :

- une ambiguïté métier ;
- une responsabilité mal placée ;
- un concept insuffisamment compris ;
- ou un modèle encore immature.

------

## Le modélisateur doit connaître les contraintes du logiciel

L'inverse est tout aussi vrai.

Un modèle qui semble élégant sur un tableau blanc peut s'avérer :

- excessivement complexe ;
- difficile à maintenir ;
- peu performant ;
- incompatible avec certaines contraintes techniques.

C'est pourquoi Evans insiste sur la nécessité pour les concepteurs de rester proches de l'implémentation.

Le bon modèle n'est pas seulement celui qui décrit correctement le métier.

Le bon modèle est celui qui :

- révèle les concepts essentiels ;
- favorise un langage ubiquitaire clair ;
- peut être implémenté naturellement ;
- reste maintenable dans le temps.

------

## Une lecture moderne

Ce pattern résonne particulièrement avec de nombreuses pratiques contemporaines :

- Event Storming ;
- Example Mapping ;
- Pair Programming ;
- Mob Programming ;
- Software Design Workshops ;
- Team Topologies ;
- eXtreme Programming.

Dans toutes ces approches, la connaissance métier n'est pas produite par un groupe puis transmise à un autre. Elle est construite collectivement.

On retrouve ici l'idée que vous défendez régulièrement dans vos travaux sur le DDD et les organisations : **la compréhension du domaine est une responsabilité de l'équipe dans son ensemble, et non d'un rôle spécialisé.**

Une équipe Stream-Aligned performante n'est pas composée d'experts métier d'un côté et de développeurs de l'autre. Elle rassemble des personnes qui contribuent ensemble à un même problème métier et qui partagent progressivement une compréhension commune du domaine.

------

## Le message fondamental d’Eric Evans

Ce pattern peut être résumé par une idée simple :

> **Ceux qui modélisent doivent coder, et ceux qui codent doivent modéliser.**

Lorsque le modèle reste connecté à l'implémentation et que l'implémentation reste connectée au métier, une boucle d'apprentissage permanente s'installe :

```
Métier
   ↕
Modèle
   ↕
Code
```

C'est cette boucle de rétroaction continue qui permet au logiciel d'évoluer tout en conservant sa cohérence et sa capacité à exprimer fidèlement le domaine métier.

### Refactoring vers une compréhension plus profonde du domaine (Refactoring Toward Deeper Insight)

L'utilisation d'un ensemble éprouvé de briques de construction (building blocks) ainsi qu'un langage cohérent apportent une certaine stabilité au développement logiciel. Cependant, cela ne résout pas le défi principal : découvrir un modèle véritablement pertinent, capable de capturer les subtilités du domaine métier tout en servant de fondation à une conception logicielle efficace.

Un modèle qui parvient à éliminer les aspects superficiels pour révéler les mécanismes essentiels du domaine est ce qu'Eric Evans appelle un **modèle profond (Deep Model)**.

Un tel modèle permet au logiciel :

- d'être davantage aligné sur la manière dont les experts métier perçoivent leur activité ;
- de mieux répondre aux besoins réels des utilisateurs ;
- de mieux résister aux évolutions du domaine.

Traditionnellement, le refactoring est présenté comme une série de transformations techniques du code destinées à améliorer sa qualité interne. Dans le Domain-Driven Design, le refactoring peut également être motivé par une meilleure compréhension du métier et conduire à un raffinement du modèle lui-même, ainsi que de son expression dans le code.

Les modèles métier sophistiqués émergent rarement dès la première tentative. Ils résultent généralement d'un processus itératif de refactoring, mené en étroite collaboration entre les développeurs et les experts du domaine.

------

## Interprétation en DDD

Ce pattern introduit l'une des idées les plus puissantes du Domain-Driven Design :

> **Le refactoring ne sert pas seulement à améliorer le code. Il sert à améliorer le modèle.**

Dans l'approche traditionnelle, un développeur refactorise pour :

- réduire la duplication ;
- améliorer la lisibilité ;
- diminuer le couplage ;
- simplifier une structure technique.

Dans le DDD, une autre motivation apparaît :

- révéler un concept métier caché ;
- clarifier une règle métier ;
- faire émerger une nouvelle abstraction du domaine ;
- améliorer le langage ubiquitaire.

Le refactoring devient alors un outil d'exploration du domaine.

------

## Du code vers le modèle

Les équipes découvrent rarement le bon modèle dès le départ.

Au début d'un projet, elles manipulent souvent :

- des concepts approximatifs ;
- des responsabilités mal réparties ;
- des termes ambigus ;
- des règles métier implicites.

À mesure que les conversations se multiplient avec les experts métier, de nouvelles compréhensions émergent.

Ces découvertes conduisent à des questions telles que :

- Ce concept représente-t-il réellement une Entité ou plutôt un Objet Valeur ?
- Cette règle appartient-elle à cet Agrégat ?
- Ces deux notions sont-elles réellement différentes ?
- Ce terme du langage ubiquitaire est-il suffisamment précis ?

Chaque réponse peut conduire à un refactoring du modèle puis du code.

------

## Le Deep Model

Le véritable objectif est d'atteindre ce qu'Evans appelle un **modèle profond**.

Un modèle superficiel reflète principalement :

- les écrans ;
- les formulaires ;
- les structures de données ;
- les processus administratifs visibles.

Un modèle profond révèle :

- les invariants métier ;
- les intentions du domaine ;
- les mécanismes de décision ;
- les contraintes fondamentales.

Par exemple, dans votre contexte de réservation de sièges de théâtre, un modèle superficiel pourrait simplement manipuler :

```
Seat
Row
Reservation
```

Un modèle plus profond pourrait faire émerger des concepts tels que :

```
Adjacent Seating
Party Seating Preference
Center-of-Row Distance
Best Seating Offer
```

Ces concepts n'apparaissent pas nécessairement dans l'interface utilisateur, mais ils traduisent la véritable logique métier qui guide les décisions.

------

## Pourquoi les experts métier sont indispensables

Evans insiste sur un point souvent oublié :

Les développeurs ne peuvent pas découvrir seuls un modèle profond.

Les experts métier détiennent :

- les exceptions ;
- les subtilités ;
- les compromis ;
- les heuristiques ;
- les connaissances tacites.

Les développeurs apportent quant à eux :

- les techniques de modélisation ;
- les capacités d'abstraction ;
- la mise à l'épreuve des concepts dans le code.

Le Deep Modeling naît de cette collaboration.

------

## Une lecture moderne

Aujourd'hui, ce pattern trouve un écho direct dans :

- l'Event Storming ;
- l'Example Mapping ;
- le Domain Storytelling ;
- le Pair Programming ;
- le Mob Programming ;
- les ateliers de conception collaborative.

Ces pratiques ne servent pas uniquement à recueillir des exigences. Elles permettent de découvrir progressivement des concepts plus profonds du domaine.

C'est également la raison pour laquelle les équipes qui pratiquent le TDD et le refactoring de manière intensive développent souvent de meilleurs modèles métier. Le code devient un laboratoire où les hypothèses sur le domaine sont continuellement testées, remises en question et affinées.

------

## Le message fondamental d’Evans

Ce pattern peut être résumé ainsi :

> **Le premier modèle n'est presque jamais le bon modèle.**

Le rôle d'une équipe DDD n'est pas de découvrir immédiatement la solution parfaite, mais d'engager un processus d'apprentissage continu dans lequel :

```
Compréhension métier
          ↓
     Nouveau modèle
          ↓
      Refactoring
          ↓
    Meilleur logiciel
          ↓
 Nouvelles découvertes
```

Le refactoring devient alors bien plus qu'une pratique technique : il constitue le mécanisme principal par lequel une équipe approfondit sa compréhension du domaine et construit progressivement un modèle capable d'exprimer l'essence même du métier.

### Les briques de construction d’une conception pilotée par le modèle

*(Building Blocks of a Model-Driven Design)*

Ces patterns reprennent les bonnes pratiques largement reconnues de la conception orientée objet et les réinterprètent à la lumière du Domain-Driven Design.

Ils guident les décisions de conception afin de :

- clarifier le modèle métier ;
- maintenir l’alignement entre le modèle et l’implémentation ;
- faire en sorte que le modèle et le code se renforcent mutuellement.

Le soin apporté à la conception des éléments constitutifs du modèle fournit aux développeurs une base solide leur permettant :

- d’explorer de nouvelles compréhensions du domaine ;
- de faire évoluer le modèle ;
- de conserver une correspondance étroite entre les concepts métier et leur implémentation logicielle.

------

## Interprétation en DDD

Cette section marque une transition importante dans la pensée d’Eric Evans.

Les chapitres précédents décrivent principalement :

- la collaboration avec les experts métier ;
- le Langage Ubiquitaire ;
- les Bounded Contexts ;
- le Deep Modeling ;
- le Model-Driven Design.

Autrement dit, ils expliquent **pourquoi** modéliser.

À partir de cette section, Evans s'intéresse davantage à **comment traduire un modèle dans le code**.

Pour cela, il introduit ce que l'on appelle aujourd'hui les **Building Blocks du DDD**.

------

## Pourquoi des Building Blocks ?

Lorsqu'une équipe découvre progressivement un modèle métier pertinent, une question apparaît rapidement :

> Comment exprimer ce modèle dans le code sans perdre sa signification ?

Sans conventions partagées, les développeurs risquent d'utiliser des structures techniques arbitraires :

- classes utilitaires ;
- services omnipotents ;
- objets anémiques ;
- procédures déguisées en objets.

Le modèle devient alors difficile à lire et cesse d'être une représentation fidèle du domaine.

Les Building Blocks apportent un vocabulaire de conception permettant de représenter explicitement différents types de concepts métier.

------

## Les principaux Building Blocks

Eric Evans introduit notamment :

| Building Block     | Rôle                                                         |
| ------------------ | ------------------------------------------------------------ |
| **Entity**         | Représente un objet défini par son identité et sa continuité dans le temps. |
| **Value Object**   | Représente un concept défini uniquement par ses attributs et sans identité propre. |
| **Aggregate**      | Délimite une frontière de cohérence et protège les invariants métier. |
| **Repository**     | Fournit l'accès aux agrégats en masquant les mécanismes de persistance. |
| **Factory**        | Gère la création d'objets ou d'agrégats complexes.           |
| **Domain Service** | Porte un comportement métier qui n'appartient naturellement à aucune entité ou objet valeur. |
| **Domain Event**   | Représente un fait métier significatif survenu dans le domaine. |

Ces patterns ne sont pas de simples recettes techniques. Ils existent pour préserver la clarté du modèle.

------

## Un langage de conception

L'une des contributions majeures de cette section est d'introduire un langage partagé entre développeurs.

Lorsqu'une équipe dit :

> « Réservation est une Entité »
>  « Adresse est un Objet Valeur »
>  « Commande est la racine d'un Agrégat »

elle ne parle plus uniquement de code. Elle exprime une compréhension du domaine.

Les Building Blocks prolongent donc le Langage Ubiquitaire jusque dans la conception logicielle.

------

## Le lien avec le Deep Modeling

Il est important de comprendre qu'Evans ne présente jamais ces patterns comme une fin en soi.

Un projet peut parfaitement contenir :

- des Entités ;
- des Objets Valeur ;
- des Agrégats ;
- des Repositories ;

sans pour autant pratiquer réellement le DDD.

Les Building Blocks ne créent pas le modèle.

Ils servent à **exprimer un modèle déjà découvert**.

Le véritable travail reste :

- comprendre le métier ;
- collaborer avec les experts ;
- faire émerger un Langage Ubiquitaire ;
- découvrir des concepts profonds.

Les Building Blocks ne sont que les outils qui permettent ensuite de matérialiser cette compréhension dans le logiciel.

------

## Une lecture moderne

Avec le temps, de nombreuses équipes ont réduit le DDD à ses Building Blocks.

On voit souvent apparaître des architectures remplies de :

- `OrderAggregate`
- `CustomerRepository`
- `InvoiceFactory`
- `PaymentService`

sans véritable réflexion sur le domaine sous-jacent.

C'est précisément l'inverse du message d'Evans.

Les Building Blocks n'ont de valeur que lorsqu'ils servent un modèle métier riche.

Comme vous le soulignez souvent dans vos formations DDD, **un Agrégat mal compris reste un mauvais modèle, même s'il respecte parfaitement la définition technique d'un Agrégat**.

------

## Le message fondamental d’Eric Evans

Cette introduction peut être résumée ainsi :

> **Les Building Blocks fournissent une grammaire de conception permettant de traduire le modèle métier dans le logiciel.**

Ils constituent le chaînon manquant entre :

```
Compréhension du métier
          ↓
      Modèle
          ↓
 Building Blocks
          ↓
        Code
```

Leur objectif n'est pas d'ajouter de la sophistication technique, mais de permettre au logiciel de rester l'expression fidèle du domaine métier à mesure qu'il évolue.

# Architecture en couches (Layered Architecture)

Dans un programme orienté objet, il est fréquent que le code lié à l’interface utilisateur, à la base de données ou à d’autres préoccupations techniques soit directement intégré aux objets métier. De même, une partie de la logique métier se retrouve parfois dispersée dans les composants de l’interface graphique, les scripts de base de données ou d’autres éléments techniques.

Cette situation apparaît souvent parce qu’elle constitue la manière la plus simple de faire fonctionner le système à court terme.

Cependant, lorsque le code métier est disséminé dans une grande quantité de code technique, il devient extrêmement difficile à identifier, à comprendre et à faire évoluer. Une modification apparemment anodine de l’interface utilisateur peut alors affecter des règles métier. Inversement, faire évoluer une règle métier peut nécessiter l’analyse minutieuse de code d’interface, de scripts SQL ou d’autres composants techniques.

Dans ces conditions :

- la conception pilotée par le modèle devient difficile à maintenir ;
- les objets métier perdent leur cohérence ;
- les tests automatisés deviennent complexes à mettre en œuvre ;
- la compréhension globale du système se dégrade rapidement.

Lorsque chaque activité implique simultanément des technologies, des responsabilités et des logiques de nature différente, le système doit rester très simple pour demeurer compréhensible. Dès que sa complexité augmente, il devient pratiquement impossible à maîtriser.

## Par conséquent

Isolez l’expression du modèle métier et de la logique métier.

Éliminez toute dépendance directe du modèle vers :

- l’infrastructure ;
- l’interface utilisateur ;
- les mécanismes techniques ;
- la logique applicative qui n’appartient pas au domaine.

Découpez le système en couches distinctes.

À l’intérieur de chaque couche :

- recherchez une forte cohésion ;
- limitez les dépendances aux couches inférieures ;
- utilisez des mécanismes de couplage faible avec les couches supérieures.

Concentrez l’ensemble du code métier dans une couche dédiée et protégez-la des préoccupations liées :

- à l’interface utilisateur ;
- à l’orchestration applicative ;
- à la persistance ;
- à l’infrastructure.

Les objets du domaine, libérés des responsabilités liées à l’affichage, au stockage ou à la coordination technique, peuvent alors se concentrer exclusivement sur l’expression du modèle métier.

Cette séparation permet au modèle :

- de devenir plus riche ;
- de gagner en clarté ;
- de capturer les connaissances essentielles du métier ;
- de soutenir efficacement l’évolution du système.

L’objectif fondamental est l’**isolation**.

D’autres architectures, comme l’architecture hexagonale, peuvent servir cet objectif de manière équivalente, voire supérieure, dès lors qu’elles permettent au modèle métier d’éviter toute dépendance envers les autres préoccupations du système.

------

# Interprétation en DDD

Cette section est souvent associée à tort à l’architecture en couches traditionnelle :

```
Présentation
    ↓
Métier
    ↓
Persistance
    ↓
Base de données
```

Pourtant, le message d’Eric Evans est beaucoup plus profond.

Le véritable objectif n’est pas de créer des couches.

Le véritable objectif est de **protéger le modèle métier**.

------

## Le problème fondamental : la pollution du modèle

Dans les systèmes d’entreprise, le métier est souvent noyé dans des préoccupations techniques :

```
public class Reservation
{
    [Table("RESERVATION")]
    [JsonProperty]
    [HttpPost]
    public void Save()
    {
        // SQL
        // Validation
        // UI
        // Métier
    }
}
```

L’objet métier devient alors :

- un objet de persistance ;
- un objet d’API ;
- un objet d’interface ;
- un objet de sérialisation ;

et seulement accessoirement un objet métier.

Le domaine disparaît derrière la technique.

------

## L’idée centrale : préserver la pureté du modèle

Evans cherche à créer un espace protégé où le modèle peut évoluer indépendamment des choix techniques.

Dans cet espace :

- les Entités expriment le métier ;
- les Objets Valeur expriment le métier ;
- les Agrégats expriment le métier ;
- les Services de Domaine expriment le métier.

Ils ignorent :

- SQL ;
- HTTP ;
- Kafka ;
- RabbitMQ ;
- MongoDB ;
- React ;
- Angular ;
- Kubernetes.

Le domaine décrit uniquement les règles du métier.

------

## La naissance du Domain Layer

C’est précisément dans ce chapitre qu’apparaît la notion de **Domain Layer**.

```
+----------------------+
| Presentation Layer   |
+----------------------+
| Application Layer    |
+----------------------+
| Domain Layer         |
+----------------------+
| Infrastructure Layer |
+----------------------+
```

Chaque couche possède une responsabilité claire :

### Présentation

Responsable des interactions avec les utilisateurs :

- Web ;
- Mobile ;
- API publiques ;
- Interfaces graphiques.

### Application

Orchestre les cas d’usage :

- coordination ;
- transactions ;
- sécurité ;
- workflow.

Elle ne contient pas la logique métier fondamentale.

### Domaine

Contient :

- le modèle métier ;
- les règles métier ;
- les invariants ;
- les comportements du domaine.

C’est le cœur du système.

### Infrastructure

Contient :

- bases de données ;
- messagerie ;
- systèmes externes ;
- frameworks ;
- détails techniques.

------

## Pourquoi ce pattern est révolutionnaire

Au moment de la publication du livre d’Evans, de nombreux systèmes étaient organisés autour des technologies :

```
Écran
   ↓
SQL
   ↓
Code
```

Le métier n’avait pas réellement de place identifiable.

Evans inverse complètement la perspective :

```
Métier
   ↓
Modèle
   ↓
Code
   ↓
Technologies
```

La technologie devient un détail d’implémentation.

------

## Le lien avec l’architecture hexagonale

La note finale du texte est particulièrement intéressante.

Evans précise que l’architecture en couches n’est pas une fin en soi.

Ce qui compte est l’isolation du modèle.

C’est précisément cette idée qui sera reprise et approfondie quelques années plus tard par l’architecte Alistair Cockburn avec l’architecture hexagonale.

L’architecture hexagonale pousse encore plus loin cette logique :

```
        UI
         │
         ▼
      Ports
         │
         ▼
      Domaine
         ▲
         │
      Ports
         │
         ▼
 Infrastructure
```

Le domaine ne dépend plus d’aucune autre couche.

C’est pourquoi vous insistez souvent dans vos formations sur l’idée que :

> **L’architecture hexagonale n’est pas une alternative au DDD ; elle constitue l’une des meilleures matérialisations du principe d’isolation décrit par Evans.**

------

## Une lecture moderne

Avec le recul, ce pattern a influencé :

- l’architecture hexagonale ;
- le Clean Architecture ;
- l’Onion Architecture ;
- le Vertical Slice Architecture ;
- les architectures orientées domaine modernes.

Toutes poursuivent finalement le même objectif :

> **Permettre au modèle métier d’évoluer sans être contraint par les détails techniques.**

Le message essentiel d’Evans peut être résumé ainsi :

> **Les couches n’ont pas pour vocation d’organiser la technique. Elles existent pour protéger le modèle métier.**

L’architecture en couches est donc avant tout un mécanisme permettant de préserver la clarté, la cohérence et la capacité d’évolution du domaine, afin que le logiciel demeure l’expression fidèle de la connaissance métier.

# Entités (Entities)

De nombreux objets représentent un fil de continuité et d’identité qui perdure tout au long de leur cycle de vie, même lorsque leurs attributs changent.

Certains objets ne sont pas définis principalement par leurs caractéristiques ou leurs propriétés. Ils représentent avant tout une identité qui traverse le temps et parfois plusieurs représentations différentes.

Il arrive qu’un objet doive être reconnu comme étant le même qu’un autre alors que certains de ses attributs ont changé. À l’inverse, deux objets peuvent posséder exactement les mêmes attributs tout en étant des objets distincts.

Une erreur d’identité peut entraîner des conséquences graves, allant jusqu’à la corruption des données.

## Par conséquent

Lorsqu’un objet est distingué principalement par son identité plutôt que par ses attributs, faites de cette identité un élément central de sa définition dans le modèle.

Maintenez la définition de la classe simple et focalisée sur :

- son identité ;
- sa continuité dans le temps ;
- son cycle de vie.

Définissez un moyen permettant de distinguer chaque objet indépendamment de sa forme actuelle ou de son historique.

Soyez particulièrement attentif aux situations où des objets pourraient être confondus en raison de similitudes entre leurs attributs.

Définissez un mécanisme d’identification garantissant un résultat unique pour chaque objet. Cette identité peut :

- provenir du domaine lui-même ;
- être fournie par un système externe ;
- être générée par le système.

Quel que soit le mécanisme choisi, il doit correspondre à la notion d’identité telle qu’elle existe dans le modèle métier.

> **Le modèle doit définir ce que signifie être la même chose.**

------

# Interprétation en DDD

Cette dernière phrase est probablement l’une des plus importantes du livre d’Eric Evans :

> **Le modèle doit définir ce que signifie être la même chose.**

L’Entity n’est pas simplement un objet possédant un identifiant technique.

Elle représente un concept métier dont l’identité persiste malgré les changements d’état.

------

## L’identité avant les attributs

Prenons l’exemple d’un client.

Les informations suivantes peuvent évoluer :

- nom ;
- adresse ;
- numéro de téléphone ;
- adresse e-mail.

Pourtant, l’entreprise continue de considérer qu’il s’agit du même client.

```
Client #12345
```

reste :

```
Client #12345
```

même après plusieurs déménagements ou changements de coordonnées.

L’identité survit aux modifications des attributs.

C’est précisément ce qui caractérise une Entité.

------

## L’égalité métier

L’idée essentielle est que deux Entités peuvent être identiques du point de vue métier alors que leurs attributs diffèrent.

À l’inverse, deux Entités peuvent avoir exactement les mêmes attributs tout en restant distinctes.

Par exemple :

```
Réservation #A123
```

et

```
Réservation #B456
```

peuvent concerner :

- le même spectacle ;
- les mêmes sièges ;
- le même client ;
- le même montant.

Elles restent néanmoins deux réservations différentes.

La distinction repose sur leur identité et non sur leurs caractéristiques.

------

## Exemple dans le contexte des théâtres

Dans votre exemple de réservation de sièges :

### Entités

```
Reservation
Customer
Performance
Ticket
```

Ces objets possèdent une identité propre et traversent un cycle de vie.

Une réservation peut passer par plusieurs états :

```
Créée
↓
Confirmée
↓
Payée
↓
Annulée
```

Malgré ces transformations, il s’agit toujours de la même réservation.

------

### Ce qui change

```
Status
PaymentDate
Seats
Price
```

Ces attributs peuvent évoluer.

------

### Ce qui ne change pas

```
ReservationId
```

L’identité reste stable.

C’est elle qui permet de suivre l’objet dans le temps.

------

## Une Entité n'est pas une ligne de base de données

L’une des erreurs les plus fréquentes consiste à assimiler :

```
Entity = Table SQL
```

Ce n’est pas ce que dit Evans.

L’Entity est avant tout un concept métier.

L’identifiant technique n’est qu’une conséquence possible de cette identité.

Parfois l’identité existe naturellement dans le domaine :

- Numéro de compte bancaire ;
- ISIN d’un instrument financier ;
- Numéro de vol ;
- Numéro de billet.

Parfois elle doit être créée artificiellement :

- UUID ;
- GUID ;
- Identifiant interne.

Le choix technique importe moins que la capacité à représenter correctement l’identité métier.

------

## Une lecture moderne

Dans les architectures modernes, notamment celles que vous utilisez régulièrement en DDD et en architecture hexagonale, une Entité se caractérise généralement par :

```
public sealed class Reservation
{
    public ReservationId Id { get; }

    public ReservationStatus Status { get; private set; }

    public void Confirm()
    {
        ...
    }
}
```

L’identité est explicite et stable.

Les comportements métier modifient l’état de l’objet sans remettre en cause son identité.

------

## Le lien avec les Agrégats

Cette notion d’identité deviendra encore plus importante lorsque Evans introduira les Agrégats.

L’**Aggregate Root** est lui-même une Entité particulière dont l’identité représente l’ensemble de l’Agrégat.

C’est pourquoi la compréhension des Entités constitue la première étape vers une modélisation cohérente.

------

## Le message fondamental d’Eric Evans

Une Entité n’est pas un objet qui possède un identifiant.

Une Entité est :

> **un concept métier dont l’identité persiste malgré les changements d’état.**

On pourrait résumer ainsi :

```
Value Object
= même attributs → même objet

Entity
= même identité → même objet
```

La question à se poser n’est donc pas :

> « Cet objet a-t-il un identifiant ? »

mais plutôt :

> **« Le métier considère-t-il qu’il s’agit de la même chose malgré l’évolution de ses attributs ? »**

Si la réponse est oui, vous êtes probablement en présence d’une Entité.

# Objets Valeur (Value Objects)

Certains objets servent à décrire une caractéristique d'une chose ou à effectuer des calculs liés à celle-ci.

Beaucoup d'objets n'ont aucune identité conceptuelle propre.

Le suivi de l'identité des Entités est essentiel, mais attribuer une identité à tous les objets du système peut nuire aux performances, alourdir la conception et brouiller le modèle en donnant l'impression que tous les objets se ressemblent.

La conception logicielle est un combat permanent contre la complexité. Nous devons distinguer les situations qui nécessitent une gestion d'identité de celles qui n'en ont pas besoin.

Cependant, considérer ces objets uniquement comme des « objets sans identité » serait réducteur. Ils possèdent leurs propres caractéristiques et jouent un rôle important dans le modèle. Ce sont les objets qui décrivent des choses plutôt que de représenter des choses ayant une identité propre.

## Par conséquent

Lorsque seuls les attributs et les comportements associés à un élément du modèle vous intéressent, modélisez-le comme un **Objet Valeur (Value Object)**.

Faites en sorte qu'il exprime clairement la signification des attributs qu'il transporte et fournisse les comportements qui leur sont naturellement associés.

Traitez l'Objet Valeur comme **immuable**.

Toutes ses opérations doivent être des **fonctions sans effet de bord** (*Side-Effect-Free Functions*), c'est-à-dire qu'elles ne doivent dépendre d'aucun état mutable et ne doivent modifier aucun état existant.

Ne lui attribuez aucune identité et évitez ainsi toute la complexité liée à la gestion des Entités.

------

# Interprétation en DDD

Si l'Entité répond à la question :

> « De quelle chose s'agit-il ? »

L'Objet Valeur répond plutôt à la question :

> « Quelles sont ses caractéristiques ? »

L'Entity représente quelque chose qui possède une identité.

Le Value Object représente une description.

------

## L'identité n'a aucune importance

Prenons l'exemple d'une adresse.

```
12 rue Victor Hugo
78160 Marly-le-Roi
France
```

Lorsque deux adresses possèdent exactement les mêmes informations, le métier les considère généralement comme identiques.

Il n'existe aucun besoin de distinguer :

```
Adresse #1234
```

de

```
Adresse #5678
```

si elles décrivent exactement le même lieu.

L'identité n'apporte aucune valeur métier.

Ce qui compte est uniquement la valeur portée par les attributs.

------

## L'égalité par les valeurs

Contrairement à une Entité :

```
Même identité = même objet
```

Pour un Objet Valeur :

```
Mêmes attributs = même objet
```

Par exemple :

```
Money(100, EUR)
```

est identique à :

```
Money(100, EUR)
```

quelle que soit leur origine.

------

## Pourquoi l'immuabilité est importante

Evans insiste fortement sur l'immuabilité.

Un Objet Valeur ne doit jamais être modifié.

Au lieu de :

```
price.Amount = 120;
```

on crée une nouvelle valeur :

```
price = new Money(120, EUR);
```

Cette propriété apporte plusieurs avantages :

- absence d'effets de bord ;
- simplicité de raisonnement ;
- sécurité concurrente ;
- facilité de test ;
- réduction des bugs.

------

## Exemple dans le domaine des théâtres

En reprenant votre exemple de réservation de sièges :

### Entités

```
Reservation
Customer
Performance
Ticket
```

Ces concepts possèdent une identité.

------

### Objets Valeur

```
SeatNumber
RowNumber
Money
DateRange
SeatCategory
```

Ces objets décrivent des caractéristiques.

Deux objets :

```
SeatNumber(12)
```

représentent exactement la même valeur.

Aucune identité supplémentaire n'est nécessaire.

------

## Les comportements appartiennent aussi aux Value Objects

Une erreur fréquente consiste à considérer un Value Object comme un simple conteneur de données.

Evans défend exactement l'inverse.

Un Objet Valeur doit encapsuler les comportements qui lui appartiennent naturellement.

Par exemple :

```
Money.Add()
Money.Subtract()
Money.Multiply()
```

ou encore :

```
SeatNumber.IsAdjacentTo(otherSeat)
```

Dans votre atelier de réservation de sièges, la logique :

```
Le siège suivant possède le numéro courant + 1
```

peut naturellement appartenir au Value Object `SeatNumber`.

Ainsi, la connaissance métier reste proche des données qu'elle concerne.

------

## Une lecture moderne : les Value Objects comme langage du domaine

Dans les architectures modernes inspirées du DDD, les Value Objects sont souvent utilisés pour remplacer les types primitifs.

Au lieu de :

```
string isin;
decimal amount;
string currency;
```

on préfère :

```
ISIN isin;
Money amount;
Currency currency;
```

Cette pratique, souvent appelée **Primitive Obsession Refactoring**, permet :

- d'expliciter le vocabulaire métier ;
- d'encapsuler les validations ;
- de rendre le code auto-documenté ;
- de renforcer le Langage Ubiquitaire.

C'est une pratique que vous utilisez fréquemment dans vos formations de Supple Design et de modélisation d'agrégats.

------

## Le lien avec le Deep Modeling

Les équipes débutantes modélisent souvent tout sous forme d'Entités.

Au fur et à mesure que leur compréhension du domaine s'approfondit, elles découvrent que de nombreux concepts sont en réalité des descriptions plutôt que des objets ayant une identité.

Cette transformation :

```
Entity
      ↓
Value Object
```

est souvent le signe d'une compréhension plus profonde du domaine.

Evans considère même que les meilleurs modèles tendent à maximiser l'utilisation des Objets Valeur et à limiter les Entités au strict nécessaire.

------

## Le message fondamental d'Evans

On peut résumer la distinction fondamentale ainsi :

| Entité                       | Objet Valeur                    |
| ---------------------------- | ------------------------------- |
| Possède une identité         | N'a pas d'identité              |
| Évolue dans le temps         | Généralement immuable           |
| Égalité basée sur l'identité | Égalité basée sur les attributs |
| Représente une chose         | Représente une description      |
| Cycle de vie                 | Pas de cycle de vie propre      |

La question essentielle à se poser est donc :

> **« Le métier a-t-il besoin de distinguer deux instances possédant exactement les mêmes attributs ? »**

- Si oui → **Entité**
- Si non → **Objet Valeur**

C'est souvent l'une des décisions de modélisation les plus importantes, car elle détermine directement la simplicité, la clarté et l'expressivité du modèle métier.

# Événements de Domaine (Domain Events)

> **Quelque chose s'est produit et les experts métier s'en préoccupent.**

Une Entité est responsable de la gestion de son état et des règles qui encadrent son cycle de vie. Cependant, lorsqu'il devient nécessaire de comprendre les causes réelles des changements d'état, celles-ci sont généralement implicites et difficiles à retrouver.

Il peut alors devenir compliqué d'expliquer comment le système est arrivé dans son état actuel.

Les journaux d'audit permettent certes de retracer l'historique, mais ils sont rarement adaptés à une utilisation directe dans la logique métier. Les historiques d'état des Entités permettent également de consulter les états précédents, mais ils ne capturent pas la signification des changements. Toute manipulation de cette information devient alors procédurale et se retrouve souvent en dehors du modèle métier.

Un autre problème apparaît dans les systèmes distribués.

Dans un système réparti, il est impossible de maintenir une cohérence globale instantanée en permanence. Les Agrégats restent cohérents localement, tandis que les autres changements se propagent de manière asynchrone.

Lorsque les mises à jour circulent entre différents nœuds du système, il devient difficile de gérer :

- des messages arrivant dans un ordre différent ;
- des modifications concurrentes ;
- des informations incomplètes.

## Par conséquent

Modélisez l'activité du domaine sous la forme d'une série d'événements distincts.

Représentez chaque événement comme un objet du domaine à part entière.

Ces événements de domaine sont différents des événements techniques du système, qui reflètent uniquement l'activité du logiciel lui-même. Toutefois, les deux sont souvent liés : un événement technique peut être déclenché en réaction à un événement métier ou servir à transporter les informations associées à cet événement.

Un Événement de Domaine est une partie intégrante du modèle métier. Il représente quelque chose qui s'est réellement produit dans le domaine.

Ignorez les activités sans intérêt métier et rendez explicites les événements :

- que les experts métier souhaitent suivre ;
- dont ils souhaitent être informés ;
- qui entraînent des changements d'état significatifs.

Dans un système distribué, l'état d'une Entité peut être déduit des événements connus par un nœud donné, même lorsque ce nœud ne dispose pas encore d'une vision complète du système.

Les Événements de Domaine sont généralement immuables puisqu'ils représentent des faits du passé.

Ils contiennent souvent :

- une description de l'événement ;
- la date et l'heure de survenue ;
- l'identité des Entités impliquées ;
- la date et l'heure d'enregistrement dans le système ;
- l'identité de la personne ou du système ayant enregistré l'événement.

Lorsque cela est utile, un événement peut lui-même posséder une identité dérivée de ces informations afin de permettre la détection de doublons.

------

# Interprétation en DDD

Cette phrase résume parfaitement le pattern :

> **Quelque chose s'est produit et les experts métier s'en préoccupent.**

L'Événement de Domaine n'est pas une notification technique.

Il représente un fait métier.

------

## Penser en termes de faits plutôt qu'en termes d'états

Les systèmes traditionnels sont souvent construits autour des états :

```
Réservation = Confirmée
```

Mais cet état ne dit pas :

- pourquoi elle est confirmée ;
- quand elle l'a été ;
- qui l'a confirmée ;
- ce qui a provoqué ce changement.

L'événement apporte ce contexte :

```
RéservationConfirmée
```

L'événement capture un fait qui s'est produit dans le domaine.

------

## Les événements racontent l'histoire du métier

Une Entité nous dit :

```
Où en sommes-nous ?
```

Un Événement nous dit :

```
Que s'est-il passé ?
```

Par exemple :

```
ReservationCreated
↓
SeatsAllocated
↓
PaymentAuthorized
↓
ReservationConfirmed
↓
TicketsIssued
```

Cette séquence raconte l'histoire métier de la réservation.

C'est précisément cette narration qui intéresse les experts du domaine.

------

## Exemple dans le domaine des théâtres

En reprenant votre atelier de réservation de sièges :

### Entités

```
Reservation
Performance
Customer
Ticket
```

### Événements

```
ReservationCreated
SeatsReserved
PaymentAccepted
ReservationConfirmed
ReservationCancelled
TicketsIssued
```

Les experts métier parlent naturellement de ces événements :

> « Une réservation a été confirmée. »

> « Les billets ont été émis. »

> « Le paiement a été refusé. »

Le langage du métier est déjà événementiel.

------

## Événements métier versus événements techniques

Evans insiste sur une distinction essentielle.

### Événement métier

```
PaymentAccepted
```

Ce fait possède une signification métier.

------

### Événement technique

```
MessageReceived
KafkaMessagePublished
HttpRequestReceived
```

Ces événements décrivent le fonctionnement du système.

Ils ne font généralement pas partie du modèle métier.

Une erreur fréquente consiste à confondre les deux.

------

## L'immuabilité

Un événement représente un fait historique.

Par définition :

```
Ce qui s'est produit
```

ne peut plus être modifié.

On ne change pas :

```
ReservationConfirmed
```

On émet éventuellement un nouvel événement :

```
ReservationCancelled
```

Cette propriété rend les événements naturellement immuables.

------

## Le lien avec les systèmes distribués

Cette partie du texte est particulièrement visionnaire.

Lorsque Evans écrit ces lignes en 2003, les architectures événementielles sont encore peu répandues.

Pourtant il anticipe déjà les difficultés des systèmes distribués modernes :

- cohérence éventuelle ;
- propagation asynchrone ;
- concurrence ;
- duplication de messages.

Dans un environnement distribué, les événements deviennent un excellent moyen de partager la connaissance du domaine entre plusieurs systèmes.

Par exemple :

```
ReservationConfirmed
        ↓
Email Service
        ↓
Ticketing Service
        ↓
Analytics Service
        ↓
Marketing Service
```

Chaque système réagit au même fait métier.

------

## Domain Event et Event Sourcing

Il est important de distinguer deux notions souvent confondues.

### Domain Event

Pattern DDD.

Un fait métier significatif.

```
TradeExecuted
PaymentReceived
ReservationConfirmed
```

------

### Event Sourcing

Pattern d'architecture.

Les événements deviennent la source de vérité du système.

```
État actuel
=
Reconstruction des événements passés
```

On peut utiliser des Domain Events sans pratiquer l'Event Sourcing.

Eric Evans introduit ici le premier concept, pas nécessairement le second.

------

## Une lecture moderne

Aujourd'hui, les Domain Events occupent une place centrale dans :

- CQRS ;
- Event Sourcing ;
- Architecture Hexagonale ;
- Event-Driven Architecture ;
- Microservices ;
- Process Managers ;
- Sagas.

Mais leur rôle fondamental reste inchangé :

> **Rendre explicites les faits métier importants.**

Les équipes qui pratiquent l'Event Storming découvrent souvent leur modèle précisément en identifiant ces événements.

Les post-its orange représentent d'ailleurs directement les Domain Events.

------

## Le message fondamental d'Evans

Les Entités décrivent :

```
Ce qui est
```

Les Événements décrivent :

```
Ce qui s'est passé
```

Un modèle riche a généralement besoin des deux.

On pourrait résumer ainsi :

```
Entity
   → identité et état

Value Object
   → description

Domain Event
   → fait métier
```

Les événements permettent alors de raconter l'histoire du domaine dans le langage des experts métier, tout en offrant un mécanisme naturel de communication et de cohérence dans les systèmes distribués modernes.

# Services de Domaine (Services)

> **Parfois, ce n'est tout simplement pas une chose.**

Certains concepts du domaine ne se prêtent pas naturellement à une modélisation sous forme d'objet.

Forcer un comportement métier à devenir la responsabilité d'une Entité ou d'un Objet Valeur peut :

- déformer la signification du modèle ;
- attribuer des responsabilités artificielles à des objets ;
- conduire à la création d'objets sans véritable sens métier.

Dans ces situations, le comportement existe bien dans le domaine, mais il n'appartient naturellement à aucun objet particulier.

## Par conséquent

Lorsqu'un processus métier significatif ou une transformation importante du domaine n'est la responsabilité naturelle ni d'une Entité ni d'un Objet Valeur, ajoutez cette opération au modèle sous la forme d'un **Service**.

Définissez ce service comme une interface autonome représentant explicitement une capacité du domaine.

Spécifiez un contrat de service décrivant les interactions attendues et les garanties offertes par celui-ci.

Exprimez ce contrat dans le Langage Ubiquitaire du Bounded Context concerné.

Donnez au service un nom métier explicite, qui devient lui-même une partie du Langage Ubiquitaire.

------

# Interprétation en DDD

Cette phrase est probablement la meilleure définition d'un Service de Domaine :

> **Parfois, ce n'est tout simplement pas une chose.**

Le DDD encourage à modéliser le domaine à l'aide d'Entités et d'Objets Valeur.

Cependant, certains comportements métier ne trouvent naturellement leur place dans aucun objet.

La question à se poser n'est donc pas :

> « Comment faire entrer ce comportement dans une Entité ? »

mais plutôt :

> « Ce comportement appartient-il réellement à une Entité ? »

------

## Le piège du mauvais placement des responsabilités

Imaginons une réservation de théâtre.

Une Entité `Reservation` peut naturellement :

```
Confirmer une réservation
Annuler une réservation
Modifier ses sièges
```

Ces comportements concernent directement son cycle de vie.

Mais imaginons maintenant la règle métier suivante :

> Trouver le meilleur groupe de sièges adjacents disponible pour une party de quatre personnes.

À qui appartient cette responsabilité ?

- `Seat` ?
- `Row` ?
- `Reservation` ?
- `Auditorium` ?

Aucune réponse n'est totalement satisfaisante.

Nous sommes alors en présence d'une capacité métier plutôt que d'une chose métier.

------

## Le Service représente une action du domaine

Le Service de Domaine modélise généralement :

- un calcul ;
- une décision ;
- une transformation ;
- une coordination métier.

Il ne représente pas une chose identifiable du domaine.

Par exemple :

```
OfferAdjacentSeating
CalculateSettlement
AllocateTrade
DetermineBestPrice
GenerateItinerary
```

Ces concepts sont importants pour le métier, mais ils ne possèdent :

- ni identité ;
- ni état propre ;
- ni cycle de vie.

------

## Exemple dans votre atelier de réservation de sièges

Dans votre modèle de théâtre, vous utilisez une logique qui consiste à :

```
Trouver le meilleur groupe de sièges adjacents
```

Cette logique :

- traverse plusieurs sièges ;
- manipule plusieurs rangées ;
- applique plusieurs règles métier ;
- produit une décision.

Il est souvent plus naturel de la représenter par un Service :

```
public interface IAdjacentSeatingService
{
    SeatingOffer OfferSeatsFor(Party party);
}
```

Le service exprime alors une capacité métier :

> « Offrir les meilleurs sièges disponibles pour un groupe. »

------

## Les caractéristiques d'un Service de Domaine

Evans décrit implicitement trois propriétés importantes.

### 1. Il exprime une notion métier

Son nom doit appartenir au Langage Ubiquitaire.

Mauvais :

```
ReservationManager
BookingHelper
SeatProcessor
```

Bon :

```
OfferAdjacentSeating
CalculatePremium
AllocateSeats
```

------

### 2. Il est sans état

Le service ne possède généralement pas d'état métier propre.

Il reçoit :

```
Entités
Objets Valeur
```

et produit :

```
Résultats
Décisions
Transformations
```

------

### 3. Il ne remplace pas les Entités

Une erreur fréquente consiste à créer des systèmes composés uniquement de services :

```
CustomerService
OrderService
InvoiceService
PaymentService
```

avec des Entités réduites à de simples structures de données.

C'est le fameux modèle anémique (*Anemic Domain Model*).

Evans critique fortement cette approche.

Les comportements doivent rester dans les Entités lorsqu'ils leur appartiennent naturellement.

Le Service n'est utilisé qu'en dernier recours.

------

## Comment choisir entre Entité, Objet Valeur et Service ?

Une règle pratique consiste à se poser les questions suivantes :

### S'agit-il d'une chose ayant une identité ?

➡️ Entité

```
Reservation
Customer
Trade
Account
```

------

### S'agit-il d'une description ou d'une mesure ?

➡️ Objet Valeur

```
Money
SeatNumber
ISIN
Address
```

------

### S'agit-il d'une capacité ou d'un processus ?

➡️ Service

```
AllocateSeats
CalculateExposure
DetermineBestPrice
OfferAdjacentSeating
```

------

## Une lecture moderne

Dans les architectures modernes, notamment celles inspirées du DDD stratégique et de l'architecture hexagonale, les Services de Domaine jouent souvent un rôle essentiel pour encapsuler :

- des algorithmes complexes ;
- des politiques métier ;
- des calculs transverses ;
- des décisions impliquant plusieurs Agrégats.

Cependant, les meilleures équipes les utilisent avec parcimonie.

Un modèle riche tend généralement à privilégier :

```
Objets Valeur
       +
Entités comportementales
```

et à n'introduire des Services que lorsque le comportement ne possède véritablement aucun propriétaire naturel.

------

## Le message fondamental d'Eric Evans

Les Entités représentent :

```
Des choses
```

Les Objets Valeur représentent :

```
Des descriptions
```

Les Services représentent :

```
Des capacités
```

On peut résumer le pattern ainsi :

> **Lorsqu'un comportement métier important n'appartient naturellement à aucun objet du domaine, faites-en un concept explicite du modèle sous la forme d'un Service de Domaine.**

Le Service n'est donc pas un conteneur de logique métier. Il est lui-même un concept métier, nommé dans le Langage Ubiquitaire et faisant pleinement partie du modèle.

# Modules

Tout le monde utilise des modules, mais peu les considèrent comme une partie à part entière du modèle.

Le code est souvent découpé selon toutes sortes de catégories :

- les couches de l’architecture technique ;
- les responsabilités des développeurs ;
- les composants applicatifs ;
- les choix d’organisation du projet.

Même les développeurs qui refactorisent beaucoup ont tendance à conserver les modules définis au début du projet, sans les remettre réellement en question.

Les notions de **couplage** et de **cohésion** sont souvent présentées comme des métriques purement techniques, évaluées mécaniquement à partir des dépendances et des interactions dans le code.

Pourtant, ce ne sont pas seulement des morceaux de code qui sont découpés en modules, mais aussi des **concepts**.

Il existe une limite au nombre d’idées qu’une personne peut manipuler simultanément : c’est ce qui justifie la recherche d’un faible couplage. À l’inverse, des fragments d’idées incohérents sont aussi difficiles à comprendre qu’un amas indifférencié de concepts : c’est ce qui justifie la recherche d’une forte cohésion.

## Par conséquent

Choisissez des modules qui racontent l’histoire du système et qui rassemblent un ensemble cohérent de concepts.

Donnez à ces modules des noms qui deviennent eux-mêmes une partie du **Langage Ubiquitaire**.

Les modules font partie du modèle, et leurs noms doivent refléter une compréhension approfondie du domaine.

Cette approche conduit souvent à un faible couplage entre les modules. Si ce n’est pas le cas, cherchez à faire évoluer le modèle afin de démêler les concepts.

Il peut également être nécessaire d’identifier un concept oublié, susceptible de devenir la base d’un nouveau module capable de rassembler certains éléments de manière plus significative.

Recherchez un faible couplage au sens conceptuel : des concepts pouvant être compris, discutés et raisonnés indépendamment les uns des autres.

Affinez le modèle jusqu’à ce qu’il se découpe selon les concepts métier de haut niveau, et jusqu’à ce que le code correspondant soit lui aussi découplé.

------

# Interprétation en DDD

Dans cette section, Eric Evans élargit la notion de modèle.

Le modèle ne se limite pas aux Entités, Objets Valeur, Services ou Événements de Domaine.

La manière dont les concepts sont regroupés fait également partie du modèle.

Autrement dit :

> **Un module n’est pas seulement un dossier, un package ou un namespace. C’est une frontière conceptuelle.**

------

## Les modules racontent l’histoire du domaine

Un mauvais découpage technique peut produire des modules comme :

```
Controllers
Services
Repositories
Helpers
Utils
```

Ces noms parlent de technologie ou de structure logicielle, mais ils ne racontent rien du domaine.

Un découpage orienté domaine cherchera plutôt des noms comme :

```
Reservations
Seating
Pricing
Ticketing
Payments
```

Ces modules expriment les grandes zones de sens du système.

------

## Couplage et cohésion sont d’abord cognitifs

Evans rappelle que le couplage et la cohésion ne sont pas seulement des propriétés du code.

Ce sont aussi des propriétés de compréhension.

Un module fortement cohésif rassemble des concepts qui se comprennent ensemble.

Un module faiblement couplé peut être compris sans devoir connaître tout le reste du système.

Le vrai critère devient donc :

> **Puis-je comprendre ce module comme une unité de sens métier ?**

------

## Exemple dans le domaine du théâtre

Dans un système de gestion de théâtre, un découpage technique pourrait être :

```
Database
Web
Services
Models
Helpers
```

Un découpage plus aligné sur le domaine pourrait être :

```
Performances
Auditoriums
Seating
Reservations
Ticketing
Pricing
```

Chaque module porte une partie identifiable de l’histoire métier.

Par exemple :

```
Seating
```

peut contenir :

- `Seat`
- `Row`
- `SeatNumber`
- `SeatCategory`
- `SeatingOffer`
- `AdjacentSeatingPolicy`

Alors que :

```
Ticketing
```

peut contenir :

- `Ticket`
- `TicketIssued`
- `TicketNumber`
- `TicketDelivery`

Le regroupement reflète alors une compréhension du domaine, et pas seulement une organisation technique.

------

## Les modules évoluent avec le modèle

Un point important du texte est que les modules ne doivent pas être figés trop tôt.

Au début d’un projet, l’équipe ne comprend encore que partiellement le domaine. Il est donc normal que le premier découpage soit imparfait.

À mesure que la compréhension s’approfondit, certains modules doivent être :

- fusionnés ;
- scindés ;
- renommés ;
- déplacés ;
- réorganisés.

Le refactoring ne concerne donc pas seulement les classes ou les méthodes.

Il concerne aussi les frontières conceptuelles.

------

## Une lecture moderne

Cette idée résonne fortement avec les pratiques actuelles :

- Bounded Contexts ;
- Team Topologies ;
- architecture modulaire ;
- monolithes modulaires ;
- architecture hexagonale ;
- découpage par capacités métier.

Un module bien conçu peut devenir une première étape vers un Bounded Context, mais les deux notions ne doivent pas être confondues.

Un **module** est une frontière interne de conception.

Un **Bounded Context** est une frontière de modèle, de langage, d’équipe et souvent de responsabilité organisationnelle.

------

## Le message fondamental d’Eric Evans

Les modules ne doivent pas seulement organiser le code.

Ils doivent organiser la pensée.

On peut résumer ainsi :

```
Module technique
= regroupe du code selon sa nature technique

Module métier
= regroupe des concepts selon leur cohérence métier
```

Le bon module permet à l’équipe de mieux penser le système.

Il réduit la charge cognitive, clarifie le langage, révèle les concepts importants et rend le code plus aligné avec la compréhension du domaine.

C’est pourquoi, dans une conception pilotée par le modèle, les modules sont eux aussi des éléments du modèle.

# Agrégats (Aggregates)

Il est difficile de garantir la cohérence des modifications dans un modèle comportant de nombreuses associations entre objets.

Chaque objet est censé maintenir son propre état cohérent. Pourtant, il peut être affecté indirectement par des changements intervenant dans d'autres objets qui font conceptuellement partie du même ensemble métier.

Les mécanismes de verrouillage pessimiste utilisés pour protéger cette cohérence peuvent rapidement devenir problématiques :

- les utilisateurs se bloquent mutuellement ;
- les performances se dégradent ;
- le système devient difficile à faire évoluer.

Les mêmes difficultés apparaissent dans les systèmes distribués, les architectures réparties et les traitements asynchrones.

## Par conséquent

Regroupez les Entités et les Objets Valeur en **Agrégats** et définissez explicitement leurs frontières.

Choisissez une Entité qui servira de **Racine d'Agrégat (Aggregate Root)**.

Les objets extérieurs à l'agrégat ne doivent référencer que cette racine.

Les objets internes de l'agrégat ne doivent pas être directement accessibles depuis l'extérieur, sauf éventuellement durant l'exécution d'une opération locale.

Définissez les propriétés et les invariants qui s'appliquent à l'ensemble de l'agrégat et confiez leur maintien à la racine d'agrégat ou à un mécanisme explicitement prévu à cet effet.

Utilisez les frontières de l'agrégat pour guider :

- les transactions ;
- la cohérence ;
- la distribution ;
- la synchronisation des données.

À l'intérieur d'un agrégat, les règles de cohérence doivent être appliquées de manière synchrone.

Entre plusieurs agrégats, les mises à jour doivent être traitées de manière asynchrone.

Conservez autant que possible un agrégat sur un même nœud ou serveur et autorisez la distribution uniquement entre agrégats distincts.

Lorsque ces décisions deviennent difficiles à prendre ou semblent artificielles, réexaminez le modèle. Ces difficultés révèlent souvent une compréhension incomplète du domaine ou l'existence d'un concept métier encore non identifié.

------

# Interprétation en DDD

L'Agrégat est probablement le concept du DDD qui a été le plus étudié, mais aussi le plus mal compris.

Beaucoup de développeurs le réduisent à :

> « Un ensemble d'objets reliés entre eux. »

Ce n'est pas ce qu'Evans décrit ici.

La notion centrale n'est pas la composition.

La notion centrale est :

> **La cohérence métier.**

------

## Le véritable problème : protéger les invariants

Prenons un exemple simple.

Une réservation de théâtre ne peut pas contenir plus de sièges que ceux qui ont été réellement attribués.

Cette règle doit toujours être vraie.

```
Nombre de billets émis
=
Nombre de sièges réservés
```

Cette propriété est un invariant métier.

Si plusieurs objets peuvent être modifiés indépendamment, cet invariant risque d'être violé.

L'Agrégat existe précisément pour protéger ce type de règle.

------

## L'Agrégat définit une frontière de cohérence

Un Agrégat délimite :

```
Ce qui doit être cohérent immédiatement
```

À l'intérieur de cette frontière :

```
Transaction unique
+
Validation immédiate
+
Invariants garantis
```

À l'extérieur :

```
Cohérence éventuelle
+
Propagation asynchrone
```

C'est la raison pour laquelle Evans relie directement les Agrégats aux transactions.

------

## La racine d'agrégat

Chaque Agrégat possède une Entité particulière :

```
Aggregate Root
```

La racine :

- contrôle les accès ;
- protège les invariants ;
- coordonne les modifications.

Les objets extérieurs ne doivent référencer que cette racine.

------

### Exemple

```
Reservation
 ├─ Ticket
 ├─ SeatAssignment
 └─ PaymentInformation
```

Ici :

```
Reservation
```

peut être la racine d'agrégat.

Depuis l'extérieur :

```
reservation.Confirm();
reservation.Cancel();
reservation.AssignSeats(...);
```

mais jamais :

```
ticket.Status = Issued;
seatAssignment.Seat = seat42;
```

car cela contournerait les règles métier.

------

# Exemple dans votre atelier de réservation de sièges

Dans votre modèle de théâtre, on pourrait imaginer :

```
Reservation (Aggregate Root)
 ├─ ReservedSeat
 ├─ Party
 └─ ReservationStatus
```

La règle :

> Une réservation confirmée doit posséder exactement les sièges attribués à la Party.

est protégée par la racine.

Toute modification passe donc par :

```
reservation.Confirm();
reservation.AssignSeats(bestSeats);
```

et jamais directement par les objets internes.

------

## Ce que l'Agrégat n'est pas

Une erreur classique consiste à construire de gigantesques agrégats :

```
Theater
 ├─ Performances
 ├─ Reservations
 ├─ Tickets
 ├─ Customers
 ├─ Payments
 └─ Seats
```

Techniquement cela fonctionne.

Mais chaque modification exige alors :

- une transaction énorme ;
- des verrous nombreux ;
- une forte contention.

Le système devient difficile à distribuer.

------

## Le lien avec les systèmes distribués

Cette partie du texte est remarquable car Evans anticipe déjà les architectures modernes.

Il propose :

### Cohérence forte à l'intérieur

```
Aggregate
```

### Cohérence éventuelle à l'extérieur

```
Aggregate A
      ↓ Event
Aggregate B
```

Aujourd'hui, cette idée est au cœur :

- des microservices ;
- du CQRS ;
- de l'Event Sourcing ;
- des architectures événementielles.

------

## Une lecture moderne

Avec le recul, on peut résumer la pensée d'Evans ainsi :

Un Agrégat n'est pas défini par :

- la structure des objets ;
- les relations UML ;
- les clés étrangères.

Il est défini par :

> **les invariants métier qui doivent être protégés dans une même transaction.**

Cette définition est probablement la plus utile pour les équipes modernes.

Lorsqu'un invariant exige une cohérence immédiate :

```
Même Agrégat
```

Lorsqu'une cohérence éventuelle est acceptable :

```
Agrégats différents
```

------

## Agrégat et charge cognitive

Cette vision rejoint également vos travaux sur :

- les Bounded Contexts ;
- les capacités métier ;
- Team Topologies.

Un bon Agrégat possède généralement :

- un langage cohérent ;
- des invariants clairement identifiés ;
- une taille maîtrisable ;
- une responsabilité compréhensible.

Lorsqu'un Agrégat devient difficile à expliquer sur un tableau blanc, cela indique souvent qu'il est trop grand ou que le modèle n'est pas encore suffisamment raffiné.

------

## Le message fondamental d'Eric Evans

L'Agrégat n'est pas un mécanisme de regroupement d'objets.

C'est :

> **une frontière de cohérence métier.**

On peut résumer l'idée ainsi :

```
Entité
    ↓
Objet métier identifiable

Objet Valeur
    ↓
Description immuable

Service
    ↓
Capacité métier

Agrégat
    ↓
Frontière protégeant les invariants
```

La question essentielle n'est donc pas :

> « Quels objets sont liés ? »

mais :

> **« Quelles règles métier doivent rester vraies immédiatement après chaque modification ? »**

La réponse à cette question détermine presque toujours les véritables frontières des Agrégats.

# Dépôts (Repositories)

> **Un accès aux Agrégats exprimé dans le Langage Ubiquitaire.**

La multiplication des associations navigables uniquement destinées à retrouver des objets finit par brouiller le modèle.

Dans les modèles matures, les requêtes expriment souvent des concepts métier importants. Pourtant, elles introduisent également plusieurs difficultés.

La complexité technique des mécanismes d'accès aux données envahit rapidement le code applicatif. Les développeurs se retrouvent alors à écrire davantage de code d'accès aux données que de code métier.

Progressivement :

- la couche domaine s'appauvrit ;
- le modèle perd son importance ;
- les objets métier deviennent de simples structures de données.

Les frameworks de requêtage permettent certes de masquer une partie de cette complexité, mais ils ne résolvent pas le problème fondamental.

Des requêtes trop libres peuvent :

- accéder directement aux attributs internes des objets ;
- contourner l'encapsulation ;
- récupérer des objets internes à un Agrégat sans passer par sa racine ;
- déplacer la logique métier vers les requêtes ou la couche applicative.

Dans ce cas, les Entités et les Objets Valeur cessent d'être des objets métier pour devenir de simples conteneurs de données.

## Par conséquent

Pour chaque type d'Agrégat nécessitant un accès global, créez un service capable de donner l'illusion d'une collection en mémoire contenant toutes les instances de la racine d'agrégat.

Exposez cet accès au travers d'une interface connue et explicite.

Le dépôt doit fournir :

- des méthodes d'ajout ;
- des méthodes de suppression ;
- des méthodes de recherche exprimées dans le langage du domaine.

Les critères de recherche doivent être significatifs pour les experts métier.

Les dépôts retournent :

- des Agrégats entièrement reconstitués ;
- ou des collections d'Agrégats ;
- éventuellement des proxies permettant un chargement différé.

Les détails liés :

- à la persistance ;
- aux bases de données ;
- aux technologies de stockage ;
- aux mécanismes de requêtage ;

doivent rester entièrement cachés derrière le dépôt.

Créez des dépôts uniquement pour les racines d'Agrégat qui nécessitent réellement un accès direct.

La logique applicative doit rester focalisée sur le modèle métier et déléguer complètement le stockage et la récupération des objets aux dépôts.

------

# Interprétation en DDD

Le Repository est probablement l'un des patterns les plus mal compris du DDD.

La plupart des équipes le résument à :

```
IRepository<T>
```

ou à une simple couche d'accès aux données.

Pour Evans, le Repository est beaucoup plus que cela.

Il constitue :

> **la porte d'entrée du modèle.**

------

## L'illusion d'une collection métier

La phrase la plus importante de cette définition est :

> « Donner l'illusion d'une collection en mémoire de tous les Agrégats. »

Pour le domaine, il devrait être possible d'écrire :

```
var reservation =
    reservationRepository
        .GetById(reservationId);
```

sans se préoccuper de savoir si les données proviennent :

- d'une base SQL ;
- de MongoDB ;
- d'un fichier ;
- d'un service distant ;
- d'un Event Store.

Le Repository masque totalement cette complexité.

------

## Le Repository protège les Agrégats

Le lien avec le chapitre précédent est fondamental.

Evans vient d'introduire les Agrégats.

Les règles sont :

```
Accès externe
        ↓
Aggregate Root
        ↓
Objets internes
```

Le Repository renforce cette contrainte.

On ne doit pas pouvoir écrire :

```
SeatAssignment assignment =
    db.SeatAssignments.Find(id);
```

si `SeatAssignment` est interne à un Agrégat.

On doit récupérer :

```
Reservation reservation =
    reservationRepository.Get(id);
```

puis laisser la racine protéger les invariants.

Le Repository devient donc un gardien des frontières de l'Agrégat.

------

## Le Repository parle le langage du métier

Une autre idée essentielle du texte est que les requêtes doivent être exprimées dans le Langage Ubiquitaire.

Mauvais exemple :

```
FindByColumn(string field, object value)
```

ou :

```
ExecuteSql(...)
```

Ces opérations parlent de technique.

------

Meilleur exemple :

```
FindReservationByNumber(...)
FindAvailableSeatsFor(...)
FindTradesPendingValidation(...)
```

Ces méthodes expriment directement des concepts métier.

Le Repository devient alors un prolongement du modèle.

------

## Exemple dans votre contexte de théâtre

Imaginons les Agrégats suivants :

```
Reservation
Performance
Customer
```

On pourrait définir :

```
IReservationRepository
```

avec :

```
Reservation Get(ReservationId id);

void Add(Reservation reservation);

IEnumerable<Reservation>
FindConfirmedReservations();
```

ou encore :

```
IPerformanceRepository
```

avec :

```
Performance Get(PerformanceId id);

IEnumerable<Performance>
FindUpcomingPerformances();
```

Ces méthodes racontent une histoire métier.

Elles ne parlent jamais :

- de SQL ;
- de tables ;
- de jointures ;
- de schémas.

------

## Pourquoi Eric Evans critique les requêtes libres

Cette partie est souvent négligée.

Evans met en garde contre les requêtes qui traversent librement le modèle :

```
SELECT *
FROM Reservation
JOIN Seat
JOIN Ticket
JOIN Customer
...
```

Ces requêtes finissent souvent par :

- contourner les Agrégats ;
- exposer des détails internes ;
- déplacer la logique métier dans les requêtes.

Le modèle devient alors anémique.

Les objets métier perdent leur rôle.

------

## Repository et architecture hexagonale

Cette idée deviendra plus tard centrale dans l'architecture hexagonale.

Le Repository devient un Port :

```
Domaine
    ↓
IReservationRepository
    ↓
Infrastructure
    ↓
SQL / MongoDB / API
```

Le domaine ne connaît que l'interface.

L'infrastructure fournit l'implémentation.

Cette séparation permet au modèle de rester indépendant des technologies.

------

## Une lecture moderne

Aujourd'hui, beaucoup d'équipes ont remplacé les Repositories génériques par des interfaces spécifiques au domaine :

```
ITradeRepository
IReservationRepository
ICustomerRepository
```

Cette approche correspond davantage à la vision d'Evans.

Le Repository n'est pas une abstraction générique de la base de données.

Il représente :

> **un mécanisme métier permettant d'obtenir des Agrégats.**

------

## Le lien avec CQRS

Avec CQRS, cette idée est souvent raffinée :

### Côté Commande

Repository :

```
Chargement d'Agrégats
Protection des invariants
Modifications métier
```

### Côté Lecture

Read Models :

```
Requêtes optimisées
Projection
Reporting
```

Cette distinction répond précisément à certaines limites évoquées par Evans concernant les requêtes complexes.

------

## Le message fondamental d'Eric Evans

Le Repository n'est pas une couche d'accès aux données.

C'est :

> **une abstraction métier donnant accès aux racines d'Agrégat tout en protégeant les frontières du modèle.**

On peut résumer ainsi :

```
Entity
    ↓
Identité

Value Object
    ↓
Description

Service
    ↓
Capacité

Aggregate
    ↓
Cohérence

Repository
    ↓
Accès aux Agrégats
```

La question à se poser n'est donc pas :

> « Comment accéder à la base de données ? »

mais :

> **« Comment permettre au domaine d'accéder à ses Agrégats sans connaître les détails de leur stockage ? »**

C'est précisément le rôle du Repository dans le Domain-Driven Design.

# Fabriques (Factories)

Lorsque la création d'un Agrégat complet et cohérent, ou d'un Objet Valeur complexe, devient compliquée ou expose trop de détails internes, les **Factories** permettent d'encapsuler cette complexité.

La création d'un objet peut constituer une opération métier importante à part entière. Cependant, les opérations complexes d'assemblage ne relèvent généralement pas de la responsabilité des objets créés eux-mêmes.

Mélanger ces responsabilités produit souvent :

- des conceptions lourdes ;
- des objets difficiles à comprendre ;
- une encapsulation affaiblie ;
- un couplage excessif entre les clients et les détails d'implémentation.

Lorsque le client doit orchestrer lui-même toutes les étapes de construction, il finit par connaître :

- la structure interne de l'objet ;
- les règles de création ;
- les dépendances nécessaires ;
- les invariants à respecter.

Cette connaissance devrait pourtant rester encapsulée.

## Par conséquent

Déplacez la responsabilité de création des objets complexes et des Agrégats vers un objet dédié : la **Factory**.

Cette Factory peut ne posséder aucune responsabilité métier propre, tout en restant un élément important du design du domaine.

Exposez une interface qui :

- encapsule la complexité de création ;
- masque les détails d'assemblage ;
- évite au client de dépendre des classes concrètes.

La Factory doit créer l'Agrégat dans son intégralité, en garantissant le respect de ses invariants.

De la même manière, elle peut construire un Objet Valeur complexe comme une unité cohérente, éventuellement en s'appuyant sur un Builder.

------

# Interprétation en DDD

Les Factories répondent à une question simple :

> **Qui est responsable de créer un objet métier complexe ?**

La réponse intuitive est souvent :

> « L'objet lui-même. »

Mais cette solution devient rapidement problématique.

------

## Le problème des constructeurs complexes

Prenons un exemple de réservation de spectacle.

Une réservation valide nécessite :

- un client ;
- une représentation ;
- des sièges ;
- une politique tarifaire ;
- un statut initial ;
- plusieurs invariants métier.

On pourrait imaginer :

```
var reservation = new Reservation(
    customer,
    performance,
    seats,
    pricingPolicy,
    status,
    ...
);
```

Plus le domaine s'enrichit, plus la construction devient complexe.

Le client doit alors connaître :

- les paramètres ;
- leur ordre ;
- les validations ;
- les objets nécessaires.

Le modèle perd en lisibilité.

------

## La Factory protège les invariants

Le véritable rôle de la Factory n'est pas simplement de masquer un constructeur.

Son rôle est de garantir qu'un objet ne puisse exister que dans un état valide.

Autrement dit :

> **Une Factory crée des objets déjà cohérents.**

Evans insiste particulièrement sur ce point pour les Agrégats.

Un Agrégat ne devrait jamais être créé dans un état invalide puis corrigé ensuite.

La Factory doit produire directement :

```
Agrégat valide
```

et non :

```
Agrégat incomplet
      ↓
Corrections
      ↓
Agrégat valide
```

------

## Exemple dans votre domaine de théâtre

Imaginons l'Agrégat :

```
Reservation
```

avec les invariants suivants :

- la Party doit contenir au moins une personne ;
- les sièges doivent être disponibles ;
- la catégorie doit être cohérente ;
- le statut initial est toujours « Pending ».

Une Factory pourrait exprimer cette intention :

```
Reservation reservation =
    reservationFactory.CreateReservation(
        performance,
        party,
        seats
    );
```

Le client exprime simplement son intention métier.

La Factory se charge :

- des validations ;
- de l'assemblage ;
- de l'initialisation ;
- du respect des invariants.

------

## Factory et Langage Ubiquitaire

Comme tous les Building Blocks du DDD, la Factory doit parler le langage du domaine.

Mauvais exemple :

```
ReservationBuilder
ObjectCreator
FactoryImpl
```

Meilleur exemple :

```
ReservationFactory
TicketIssuanceFactory
SeatingOfferFactory
```

Le nom doit refléter un concept compréhensible par les experts métier.

------

## Factory versus Service

Cette confusion est fréquente.

### Service

Le Service réalise une action métier.

```
CalculatePrice
AllocateSeats
DetermineBestOffer
```

------

### Factory

La Factory crée un objet métier.

```
CreateReservation
CreateTicket
CreateSettlement
```

La Factory n'effectue pas une capacité métier durable.

Elle construit quelque chose.

------

## Factory versus Constructeur

Evans ne dit pas que tous les objets doivent être créés via une Factory.

Pour un Objet Valeur simple :

```
Money amount = new Money(100, EUR);
```

le constructeur suffit largement.

Une Factory devient pertinente lorsque :

- la création est complexe ;
- plusieurs objets doivent être assemblés ;
- des invariants doivent être garantis ;
- le processus de création possède un sens métier.

------

## Factory et Agrégats

C'est probablement l'usage le plus important.

L'Agrégat étant responsable d'invariants métier, sa création doit être soigneusement contrôlée.

Une Factory permet de :

```
Assembler
    ↓
Valider
    ↓
Créer
    ↓
Garantir les invariants
```

avant même que l'objet ne soit utilisé.

------

## Une lecture moderne

Aujourd'hui, les Factories apparaissent souvent sous différentes formes :

### Factory classique

```
reservationFactory.Create(...)
```

### Méthode de fabrique statique

```
Reservation.Create(...)
```

### Named Constructor

```
Reservation.For(...)
```

### Builder + Factory

```
ReservationBuilder
```

suivi d'une validation finale.

Toutes ces variantes poursuivent le même objectif :

> **Créer un objet métier cohérent sans exposer sa complexité interne.**

------

## Le lien avec le Supple Design

Les Factories participent directement à ce qu'Evans appellera plus tard le **Supple Design**.

Elles permettent :

- des intentions explicites ;
- une API métier expressive ;
- des objets toujours valides ;
- un modèle plus facile à comprendre.

Le client exprime :

```
reservationFactory.CreateReservation(...)
```

plutôt que :

```
new Reservation(... 12 paramètres ...)
```

Le langage métier reste visible.

------

## Le message fondamental d'Eric Evans

Une Factory n'est pas un pattern technique destiné à masquer un constructeur.

C'est :

> **un mécanisme du domaine chargé de créer des objets complexes tout en préservant leurs invariants et leur encapsulation.**

On peut résumer les Building Blocks ainsi :

```
Entity
    → identité

Value Object
    → description

Service
    → capacité

Aggregate
    → cohérence

Repository
    → accès

Factory
    → création
```

La question à se poser est donc :

> **« La création de cet objet est-elle suffisamment complexe ou significative pour mériter un concept explicite du modèle ? »**

Si la réponse est oui, une Factory est probablement le bon choix.



# Supple Design (Conception Souple)

Pour qu'un projet accélère au fil du temps — plutôt que de s'alourdir sous le poids de son propre héritage — il faut une conception agréable à manipuler, accueillante au changement.

Il faut une **conception souple** (*Supple Design*).

Le Supple Design constitue le complément naturel du **Deep Modeling**.

Un modèle profond permet de comprendre le domaine.

Une conception souple permet de faire évoluer cette compréhension sans douleur.

------

Les développeurs jouent en réalité deux rôles différents, et le design doit répondre aux besoins des deux.

Une même personne peut alterner entre ces rôles plusieurs fois dans la même heure.

### Premier rôle : utiliser le modèle

Le développeur agit alors comme client du modèle.

Il utilise :

- les Entités ;
- les Objets Valeur ;
- les Services ;
- les Agrégats ;

pour exprimer les cas d'usage de l'application.

Dans ce contexte, un Supple Design révèle clairement le modèle sous-jacent.

Le développeur peut combiner un nombre réduit de concepts faiblement couplés pour exprimer une grande variété de scénarios métier.

Les éléments du modèle s'assemblent naturellement.

Le comportement du système devient :

- prévisible ;
- cohérent ;
- robuste ;
- facile à comprendre.

------

### Second rôle : faire évoluer le modèle

Le développeur agit alors comme concepteur.

Il doit modifier le système :

- ajouter une fonctionnalité ;
- corriger une règle métier ;
- intégrer un nouveau besoin ;
- adapter le modèle à une meilleure compréhension du domaine.

Pour rester ouvert au changement, le design doit être :

- facile à comprendre ;
- transparent ;
- aligné sur le modèle métier.

Le code doit suivre les contours du modèle profond.

Ainsi, la plupart des changements se produisent naturellement à des endroits prévus pour évoluer.

Les conséquences d'une modification doivent être visibles et faciles à anticiper.

------

## Les objectifs du Supple Design

Eric Evans résume le Supple Design autour de trois ambitions :

### Rendre les comportements évidents

Le code doit exprimer clairement son intention.

Le lecteur doit comprendre :

- ce qui se passe ;
- pourquoi cela se passe ;
- quelles règles métier sont appliquées.

Sans devoir parcourir des dizaines de classes ou de couches techniques.

------

### Réduire le coût du changement

Chaque nouvelle fonctionnalité ne doit pas nécessiter une réécriture massive du système.

Un bon design permet :

- d'ajouter ;
- de modifier ;
- de supprimer ;

des comportements avec un impact limité.

------

### Créer un logiciel agréable à développer

Le logiciel doit devenir un outil qui aide les développeurs plutôt qu'un obstacle qu'ils subissent.

Le code doit :

- inspirer confiance ;
- encourager les évolutions ;
- révéler le modèle ;
- faciliter l'expérimentation.

------

# Interprétation en DDD

Cette section constitue probablement le cœur philosophique du livre d'Eric Evans.

La plupart des lecteurs retiennent :

- les Entités ;
- les Objets Valeur ;
- les Agrégats ;
- les Repositories.

Mais Evans explique ici pourquoi ces patterns existent.

Ils ne sont pas une fin en soi.

Ils servent un objectif plus ambitieux :

> **Construire un logiciel qui devient plus facile à faire évoluer à mesure que l'on comprend mieux le métier.**

------

## Deep Modeling sans Supple Design

Une équipe peut parfaitement comprendre le domaine.

Elle peut produire :

- un excellent Event Storming ;
- un bon Langage Ubiquitaire ;
- une modélisation pertinente.

Puis implémenter le tout dans un code ressemblant à :

```
ServiceA
  ↓
ServiceB
  ↓
ManagerC
  ↓
HelperD
  ↓
FactoryE
```

Le modèle existe dans les ateliers.

Mais il disparaît dans le code.

Chaque évolution devient coûteuse.

------

## Supple Design sans Deep Modeling

L'inverse est également possible.

Un code extrêmement élégant :

```
reservation.Confirm();
ticket.Issue();
payment.Authorize();
```

mais représentant un mauvais modèle métier.

Le logiciel reste agréable à lire mais ne résout pas correctement le problème.

------

## Evans cherche la combinaison des deux

```
Deep Modeling
        +
Supple Design
        =
DDD
```

Le modèle apporte la compréhension.

Le Supple Design apporte la capacité d'évolution.

L'un sans l'autre reste insuffisant.

------

## Le lien avec vos travaux sur le Supple Design

Dans vos formations et vos ateliers autour de la réservation de sièges, vous insistez souvent sur un point :

> Un bon design permet au développeur de parler métier.

Par exemple :

```
offerAdjacentSeating.For(party);
```

est plus expressif que :

```
SeatAlgorithm.Process(seats);
```

Le premier révèle une intention métier.

Le second révèle une implémentation technique.

Cette différence est précisément l'essence du Supple Design.

------

## Le lien avec Team Topologies

Cette idée dépasse le simple code.

Elle rejoint directement la notion de charge cognitive.

Une équipe capable de comprendre rapidement :

- le modèle ;
- les règles métier ;
- les points d'extension ;

dispose d'une capacité d'évolution beaucoup plus importante.

Le Supple Design réduit la charge cognitive parce qu'il rend le système plus prévisible.

------

## Les trois conséquences recherchées

On peut résumer le Supple Design par trois propriétés :

### 1. Le code raconte le métier

```
Langage Ubiquitaire
      ↓
Code
```

------

### 2. Le changement devient local

```
Petite évolution
      ↓
Petit impact
```

------

### 3. La compréhension devient cumulative

Chaque nouvelle connaissance du domaine améliore le système au lieu de l'alourdir.

------

# Le message fondamental d'Evans

Si le Deep Modeling répond à la question :

> **« Comprenons-nous réellement le métier ? »**

Le Supple Design répond à la question :

> **« Cette compréhension est-elle visible et exploitable dans le code ? »**

On pourrait résumer toute cette partie du livre par la formule suivante :

```
Deep Modeling
    → découvrir le bon modèle

Supple Design
    → rendre ce modèle facile à utiliser
      et facile à faire évoluer
```

C'est pourquoi Evans considère le Supple Design non comme un ensemble de techniques, mais comme une qualité émergente d'un modèle profond correctement exprimé dans le logiciel.

Un système doté d'un Supple Design ne résiste pas au changement.

Il l'accompagne.

# Interfaces révélatrices d'intention (Intention-Revealing Interfaces)

Si un développeur doit examiner l'implémentation d'un composant pour pouvoir l'utiliser correctement, alors la valeur de l'encapsulation est perdue.

Si une personne autre que l'auteur initial doit déduire l'objectif d'une classe ou d'une opération en étudiant son implémentation, elle risque d'interpréter un usage qui n'était pas celui prévu à l'origine.

Le code pourra peut-être fonctionner temporairement, mais la compréhension conceptuelle du modèle sera progressivement altérée. Les développeurs finiront alors par travailler avec des représentations mentales différentes du système.

## Par conséquent

Nommez les classes et les opérations de manière à décrire :

- leur objectif ;
- leur effet ;
- leur intention métier ;

sans faire référence aux mécanismes techniques qu'elles utilisent pour accomplir leur tâche.

Ainsi, le développeur qui utilise le composant n'a pas besoin de comprendre ses détails internes.

Ces noms doivent respecter le **Langage Ubiquitaire** afin que tous les membres de l'équipe puissent immédiatement en comprendre la signification.

Écrivez un test décrivant le comportement attendu avant de créer l'implémentation. Cette pratique vous oblige à raisonner comme un utilisateur du composant plutôt que comme son implémenteur.

------

# Interprétation en DDD

Ce pattern est probablement l'un des plus importants du **Supple Design**.

Evans cherche à répondre à une question fondamentale :

> **Peut-on comprendre le code sans lire son implémentation ?**

Si la réponse est non, le modèle n'est pas suffisamment explicite.

------

## Le nom doit révéler l'intention

Prenons un exemple classique.

### Mauvais exemple

```
seatService.Process(party);
```

Que signifie :

```
Process
```

?

- Calculer ?
- Réserver ?
- Vérifier ?
- Trier ?
- Allouer ?

Impossible de le savoir.

Le lecteur est obligé d'ouvrir le code.

------

### Interface révélatrice d'intention

```
seatingOffer = adjacentSeatingService.OfferSeatsFor(party);
```

ou

```
reservation.Confirm();
```

ou encore

```
payment.Authorize();
```

Le comportement est immédiatement compréhensible.

L'implémentation devient secondaire.

------

## Décrire le "quoi", pas le "comment"

Evans insiste sur un point essentiel :

Le nom doit exprimer :

```
Ce que fait le système
```

et non :

```
Comment il le fait
```

### Mauvais exemple

```
LoadSeatsFromDatabase();
ExecuteSeatAlgorithm();
CalculateUsingRuleEngine();
```

Ces noms révèlent la mécanique.

------

### Meilleur exemple

```
FindAvailableSeats();
OfferAdjacentSeating();
DetermineBestPrice();
```

Ces noms révèlent l'intention métier.

Le développeur n'a pas besoin de connaître la technologie utilisée.

------

## Le lien avec le Langage Ubiquitaire

Pour Evans, les interfaces sont un prolongement direct du Langage Ubiquitaire.

Si les experts métier disent :

> « Attribuer des sièges adjacents »

alors le code devrait ressembler à :

```
OfferAdjacentSeating(...)
```

et non :

```
SeatAllocationManager.Process(...)
```

Le code devient alors une conversation métier.

------

## Exemple dans votre atelier de réservation de sièges

Vous utilisez régulièrement des exemples similaires :

### Peu expressif

```
FindSeats(...)
```

### Plus révélateur

```
OfferAdjacentSeatingFor(...)
```

ou :

```
FindBestCenteredAdjacentSeats(...)
```

Le second nom révèle immédiatement :

- le problème métier ;
- la règle appliquée ;
- le résultat attendu.

Le lecteur comprend l'intention sans consulter l'algorithme.

# Fonctions sans effet de bord (Side-Effect-Free Functions)

Lorsque plusieurs règles métier interagissent ou que plusieurs calculs sont composés entre eux, le comportement du système peut rapidement devenir difficile à prédire.

Le développeur qui appelle une opération doit parfois comprendre :

- son implémentation ;
- l'implémentation des méthodes qu'elle appelle ;
- les effets indirects qu'elle produit ;

simplement pour anticiper le résultat.

Dans ces conditions, l'abstraction apportée par les interfaces perd une grande partie de sa valeur. Les développeurs sont contraints de regarder derrière les abstractions pour comprendre ce qui se passe réellement.

Sans comportements prévisibles, la complexité explose rapidement.

Les développeurs limitent alors naturellement les combinaisons possibles de comportements, ce qui réduit la richesse fonctionnelle qu'ils sont capables de construire.

## Par conséquent

Placez autant que possible la logique du système dans des **fonctions sans effet de bord**.

Une fonction sans effet de bord :

- retourne un résultat ;
- ne modifie aucun état observable ;
- ne produit aucune conséquence cachée.

Séparez strictement :

### Les requêtes

Qui retournent de l'information :

```
Question
    ↓
Réponse
```

### Les commandes

Qui modifient l'état du système :

```
Action
    ↓
Modification d'état
```

Les commandes doivent rester simples et ne pas retourner d'information métier.

Réduisez encore davantage les effets de bord en déplaçant les calculs complexes vers des Objets Valeur lorsqu'un concept métier approprié existe.

Toutes les opérations d'un Objet Valeur devraient être des fonctions sans effet de bord.

------

# Interprétation en DDD

Ce pattern est directement inspiré d'une idée fondamentale :

> **Un comportement facile à prédire est un comportement facile à composer.**

Le Supple Design cherche précisément à rendre les comportements du modèle prévisibles.

------

## Le véritable problème : les surprises

Considérons une méthode :

```
price = reservation.CalculatePrice();
```

Que fait-elle réellement ?

Calcule-t-elle simplement un prix ?

Ou bien :

- met-elle à jour une base de données ?
- génère-t-elle un événement ?
- modifie-t-elle un statut ?
- réserve-t-elle des sièges ?

Le développeur ne devrait pas avoir à ouvrir le code pour le découvrir.

------

## Une fonction doit répondre à une question

Une fonction sans effet de bord répond à une question.

```
Money total = reservation.TotalPrice();
```

ou :

```
bool available = seat.IsAvailable();
```

ou :

```
Distance distance = seat.DistanceFromCenter();
```

Peu importe le nombre de fois où elles sont appelées :

```
Même entrée
      ↓
Même résultat
```

Aucun état n'est modifié.

Le système reste prévisible.

------

## Une commande doit réaliser une action

À l'inverse :

```
reservation.Confirm();
```

modifie l'état du système.

Il s'agit d'une commande.

Elle ne répond pas à une question.

Elle accomplit une action.

Evans propose donc implicitement une séparation très proche de ce qui deviendra plus tard :

> **Command Query Separation (CQS)**

de Bertrand Meyer.

------

## Exemple dans votre atelier de réservation de sièges

Prenons le calcul de la distance au centre d'une rangée.

Un siège peut calculer :

```
Distance distance =
    seat.DistanceFromCenter();
```

Cette opération :

- ne modifie pas le siège ;
- ne modifie pas la rangée ;
- ne modifie pas l'auditorium.

Elle produit simplement une information.

Nous sommes face à une fonction sans effet de bord.

------

### Exemple plus avancé

Votre algorithme :

```
Trouver le meilleur groupe
de sièges adjacents
```

peut être modélisé comme :

```
SeatingOffer offer =
    adjacentSeatingPolicy
        .OfferFor(party, seats);
```

L'opération produit un résultat.

Elle ne réserve aucun siège.

Elle ne modifie aucun état.

Elle est donc facilement :

- testable ;
- composable ;
- réutilisable.

------

## Pourquoi Eric Evans aime les Value Objects

Le texte contient une phrase très importante :

> Toutes les opérations d'un Objet Valeur devraient être des fonctions sans effet de bord.

Ce n'est pas un hasard.

Les Objets Valeur sont :

- immuables ;
- sans identité ;
- centrés sur la description.

Ils constituent donc l'endroit idéal pour héberger :

- calculs ;
- transformations ;
- règles ;
- comparaisons.

Par exemple :

```
Money total =
    amount.Add(tax);
```

ou :

```
SeatNumber next =
    seat.Next();
```

Ces opérations produisent une nouvelle valeur sans modifier l'ancienne.

------

## Le lien avec le Supple Design

Les fonctions sans effet de bord participent directement aux trois objectifs du Supple Design.

### Rendre le comportement évident

```
Entrée
   ↓
Calcul
   ↓
Résultat
```

Aucune surprise.

------

### Réduire le coût du changement

Puisqu'elles ne modifient pas l'état :

- elles sont faciles à tester ;
- elles sont faciles à déplacer ;
- elles sont faciles à recomposer.

------

### Créer un logiciel agréable à développer

Le développeur peut raisonner localement.

Il n'a pas besoin d'explorer tout le système pour comprendre les conséquences d'un appel.

------

## Le lien avec le Deep Modeling

Les équipes qui découvrent progressivement leur domaine déplacent souvent les règles métier :

```
Services
      ↓
Entités
      ↓
Objets Valeur
```

À mesure que le modèle s'affine, les calculs trouvent naturellement leur place dans des concepts métier explicites.

C'est précisément ce mouvement que décrit Evans lorsqu'il recommande de transférer la logique vers les Objets Valeur.

------

## Une lecture moderne

Aujourd'hui, ce pattern influence directement :

- le TDD ;
- la programmation fonctionnelle ;
- CQRS ;
- l'architecture hexagonale ;
- les systèmes événementiels.

On retrouve partout la même idée :

> **Les comportements qui calculent doivent calculer. Les comportements qui modifient doivent modifier. Ne mélangez pas les deux.**

------

# Le message fondamental d'Eric Evans

Une fonction sans effet de bord est :

> **une opération qui répond à une question sans modifier le monde.**

On peut résumer ainsi :

```
Commande
    ↓
Change l'état

Fonction
    ↓
Retourne une information
```

Et dans un modèle riche :

```
Le maximum de logique
      ↓
Fonctions sans effet de bord
      ↓
Objets Valeur
```

Plus les comportements du domaine sont exprimés sous forme de fonctions prévisibles, plus ils deviennent faciles à comprendre, à tester, à combiner et à faire évoluer. C'est l'un des fondements essentiels du **Supple Design**.

# Assertions

Lorsque les effets d'une opération ne sont définis qu'implicitement par son implémentation, les conceptions riches en délégations deviennent rapidement un enchevêtrement complexe de causes et de conséquences.

La seule manière de comprendre le système consiste alors à suivre l'exécution du programme pas à pas à travers de multiples branches de code.

Dans cette situation :

- l'encapsulation perd sa valeur ;
- l'abstraction devient inefficace ;
- comprendre le système nécessite de connaître son implémentation.

## Par conséquent

Définissez explicitement :

- les **post-conditions** des opérations ;
- les **invariants** des classes ;
- les **invariants** des Agrégats.

Si votre langage de programmation ne permet pas d'exprimer directement ces assertions, vérifiez-les au moyen de tests automatisés.

Exprimez également ces règles dans :

- la documentation ;
- les diagrammes ;
- les supports de modélisation ;

chaque fois que cela s'intègre naturellement aux pratiques de l'équipe.

Recherchez des modèles composés d'ensembles cohérents de concepts. Un modèle cohérent aide naturellement les développeurs à déduire les assertions attendues, accélère l'apprentissage et réduit le risque de produire du code contradictoire.

Les assertions définissent :

- les contrats des Services ;
- les contrats des opérations modifiant les Entités ;
- les invariants des Agrégats.

------

# Interprétation en DDD

Ce pattern répond à une question fondamentale :

> **Comment savoir ce qu'une opération garantit réellement ?**

Le problème n'est pas de savoir comment une méthode fonctionne.

Le problème est de savoir :

> **Ce qui est vrai après son exécution.**

------

## Les assertions rendent les règles explicites

Prenons une méthode :

```
reservation.Confirm();
```

Que garantit-elle ?

Sans assertion, impossible de le savoir.

Le développeur est obligé d'aller lire le code.

Avec des assertions explicites :

```
Précondition :
- La réservation est en attente

Post-condition :
- La réservation est confirmée
- Un paiement valide existe
- Au moins un siège est attribué
```

Le comportement devient compréhensible sans examiner l'implémentation.

------

## Evans s'intéresse davantage au "quoi" qu'au "comment"

Cette idée est directement héritée du **Design by Contract** de Bertrand Meyer.

L'important n'est pas :

```
Comment la méthode fonctionne
```

mais :

```
Ce qu'elle garantit
```

Autrement dit :

```
Implémentation
      ↓
Peut évoluer

Contrat
      ↓
Doit rester stable
```

------

# Les trois types d'assertions

## 1. Les préconditions

Ce qui doit être vrai avant l'exécution.

Par exemple :

```
Une réservation ne peut être confirmée
que si un paiement a été autorisé.
reservation.Confirm();
```

Précondition :

```
Payment.Status == Authorized
```

------

## 2. Les post-conditions

Ce qui doit être vrai après l'exécution.

Après :

```
reservation.Confirm();
```

Post-condition :

```
Reservation.Status == Confirmed
```

------

## 3. Les invariants

Ce qui doit toujours rester vrai.

Indépendamment des opérations effectuées.

Exemple :

```
Le nombre de billets émis
=
Le nombre de sièges réservés
```

Cette règle doit être vraie :

- avant l'opération ;
- après l'opération ;
- après n'importe quelle modification.

------

# Le lien avec les Agrégats

La dernière phrase du pattern est essentielle :

> **Les assertions définissent les invariants des Agrégats.**

C'est probablement l'une des meilleures définitions pratiques d'un Agrégat.

Un Agrégat existe pour protéger un ensemble d'assertions.

Par exemple :

```
Reservation Aggregate
```

Invariants :

```
Une réservation confirmée possède au moins un siège.

Une réservation annulée ne possède aucun billet valide.

Le nombre de sièges attribués correspond à la taille de la Party.
```

Toutes les opérations de l'Agrégat doivent préserver ces règles.

------

# Exemple dans votre atelier de réservation de sièges

Prenons :

```
reservation.AssignSeats(bestSeats);
```

Une assertion explicite pourrait être :

### Précondition

```
Tous les sièges sont disponibles.
```

### Post-condition

```
Tous les sièges appartiennent
à la réservation.
```

### Invariant

```
Nombre de sièges attribués
=
Taille de la Party.
```

La méthode devient immédiatement compréhensible.

------

# Assertions et TDD

Evans souligne que lorsqu'un langage ne permet pas d'exprimer directement les assertions, les tests doivent jouer ce rôle.

Par exemple :

```
[Fact]
public void Confirming_a_reservation_sets_status_to_confirmed()
{
    ...
}
```

Ce test constitue une assertion exécutable.

Il documente le contrat du modèle.

------

# Le lien avec le Supple Design

Les assertions contribuent directement aux objectifs du Supple Design.

## Comportement évident

Le développeur connaît les garanties offertes.

```
Opération
      ↓
Contrat explicite
```

------

## Réduction du coût du changement

L'implémentation peut évoluer tant que les assertions restent vraies.

```
Refactoring
      ↓
Contrat inchangé
```

------

## Logiciel agréable à faire évoluer

Les règles métier sont visibles.

Elles ne sont plus cachées dans le code.

------

# Une lecture moderne

Aujourd'hui, cette idée apparaît sous différentes formes :

- Design by Contract ;
- Tests d'acceptation ;
- Specification by Example ;
- BDD ;
- Invariants d'Agrégats ;
- Property-Based Testing ;
- Assertions exécutables.

Toutes poursuivent le même objectif :

> **Rendre explicites les règles que le système promet de respecter.**

------

# Le message fondamental d'Eric Evans

Les assertions constituent la partie visible du contrat du modèle.

On peut résumer ce pattern ainsi :

```
Précondition
    ↓
Ce qui doit être vrai avant

Post-condition
    ↓
Ce qui doit être vrai après

Invariant
    ↓
Ce qui doit toujours être vrai
```

Dans le DDD, les assertions jouent un rôle fondamental car elles rendent explicites les connaissances métier que les Entités, les Services et surtout les Agrégats sont chargés de protéger.

Elles transforment le modèle d'un simple ensemble de classes en un ensemble de **promesses métier vérifiables**, compréhensibles par les développeurs comme par les experts du domaine.

# Classes autonomes (Standalone Classes)

Même à l'intérieur d'un module cohérent, la difficulté de compréhension augmente considérablement à mesure que les dépendances se multiplient.

Chaque nouvelle dépendance impose au développeur de comprendre :

- une autre classe ;
- un autre concept ;
- une autre abstraction ;
- une autre responsabilité.

Cette accumulation augmente progressivement la charge mentale nécessaire pour raisonner sur le système.

Les concepts implicites sont souvent encore plus coûteux que les dépendances explicites, car ils restent cachés et doivent être reconstruits mentalement.

Le faible couplage est un principe fondamental de la conception orientée objet.

Lorsque cela est possible, allez jusqu'au bout de cette logique :

> Éliminez toutes les dépendances inutiles.

Une classe qui ne dépend d'aucun autre concept du modèle devient complètement autonome.

Elle peut être :

- étudiée ;
- comprise ;
- testée ;
- modifiée ;

indépendamment du reste du système.

Chaque classe autonome réduit significativement l'effort nécessaire pour comprendre un module.

------

# Interprétation en DDD

Cette section est souvent peu commentée, alors qu'elle constitue l'un des principes les plus puissants du **Supple Design**.

Evans poursuit ici son obsession de la réduction de la charge cognitive.

La question implicite est :

> **Combien de concepts dois-je comprendre avant de comprendre cette classe ?**

------

## Le coût caché des dépendances

Considérons une classe simple :

```
public class SeatNumber
{
    private readonly int value;

    public bool IsAdjacentTo(SeatNumber other)
    {
        return value + 1 == other.value;
    }
}
```

Pour comprendre cette classe, il suffit de comprendre :

```
SeatNumber
```

Rien d'autre.

------

À l'inverse :

```
public class SeatAllocator
{
    private readonly PricingService pricingService;
    private readonly ReservationRepository repository;
    private readonly EventBus eventBus;
    private readonly AvailabilityService availabilityService;
    private readonly ConfigurationProvider configurationProvider;
}
```

Pour comprendre cette classe, il faut comprendre :

```
SeatAllocator
+
PricingService
+
ReservationRepository
+
EventBus
+
AvailabilityService
+
ConfigurationProvider
```

La charge cognitive explose.

------

## Une classe autonome est compréhensible en isolation

C'est précisément ce qu'Evans recherche.

Une classe autonome peut être comprise :

```
Classe
   ↓
Compréhension
```

sans passer par :

```
Classe
   ↓
Dépendances
   ↓
Autres dépendances
   ↓
Infrastructure
   ↓
Compréhension
```

------

## Pourquoi les Value Objects sont souvent autonomes

Les meilleurs candidats à ce pattern sont souvent les Objets Valeur.

Par exemple :

```
Money
Distance
SeatNumber
ISIN
```

Ces objets :

- encapsulent une idée métier ;
- sont immuables ;
- possèdent peu de dépendances ;
- sont riches en comportement.

Ils constituent souvent les briques les plus élégantes du modèle.

------

## Exemple dans votre atelier de réservation de sièges

Prenons :

```
SeatNumber
```

Cette classe peut contenir :

```
seat.IsAdjacentTo(other);
seat.Next();
seat.Previous();
```

sans dépendre :

- d'une réservation ;
- d'un auditorium ;
- d'un repository ;
- d'un service.

Elle représente un concept autonome du domaine.

------

Même chose pour :

```
DistanceFromCenter
```

ou :

```
SeatingWeight
```

Ces concepts peuvent vivre seuls.

Ils deviennent extrêmement faciles à :

- comprendre ;
- tester ;
- réutiliser.

------

## Le lien avec le Deep Modeling

Cette section révèle une idée profonde d'Evans :

> Les meilleurs modèles découvrent des concepts capables d'exister indépendamment.

Lorsqu'une équipe affine son modèle, elle extrait souvent progressivement :

```
Grosse classe complexe
          ↓
Concept implicite découvert
          ↓
Nouvelle classe autonome
```

Cette opération simplifie simultanément :

- le modèle ;
- le code ;
- la compréhension.

------

## Le lien avec les Modules

Le chapitre précédent expliquait que :

> Les modules doivent regrouper des concepts cohérents.

Les Classes Autonomes représentent l'échelle inférieure du même principe.

```
Module cohérent
      ↓
Classes cohérentes
      ↓
Concepts autonomes
```

Le faible couplage s'applique à tous les niveaux.

------

## Une lecture moderne

Aujourd'hui, cette idée réapparaît dans plusieurs pratiques :

### Value Object First

Chercher d'abord des concepts autonomes.

### Primitive Obsession Refactoring

Transformer :

```
string
decimal
int
```

en concepts métier autonomes.

### Functional Core

Concentrer la logique dans des composants indépendants.

### Team Topologies

Réduire les dépendances entre équipes en réduisant d'abord les dépendances entre concepts.

------

## Attention : autonome ne signifie pas isolé artificiellement

Evans ne recommande pas de découper systématiquement toutes les dépendances.

Certaines dépendances sont naturelles.

Par exemple :

```
Reservation
     ↓
ReservedSeat
```

fait partie du modèle.

Le but n'est pas l'indépendance absolue.

Le but est :

> **Éliminer les dépendances qui ne contribuent pas directement à la compréhension du concept.**

------

# Le message fondamental d'Eric Evans

Une classe autonome est une classe qui peut être comprise par elle-même.

On peut résumer ce pattern ainsi :

```
Moins de dépendances
        ↓
Moins de charge cognitive
        ↓
Compréhension plus rapide
        ↓
Évolution plus facile
```

Dans le Supple Design, chaque classe autonome agit comme une unité de sens indépendante.

Elle révèle directement un concept du domaine, sans obliger le lecteur à explorer une chaîne de dépendances pour en comprendre la signification.

C'est pourquoi Evans considère les Classes Autonomes comme l'une des formes les plus abouties du faible couplage : un concept métier qui se suffit à lui-même.

# Fermeture des opérations (Closure of Operations)

La plupart des objets intéressants du domaine réalisent des opérations qui ne peuvent pas être décrites uniquement à l'aide de types primitifs.

## Par conséquent

Lorsque cela est pertinent, définissez des opérations dont le type de retour est identique au type de leurs arguments.

Si l'objet qui exécute l'opération possède lui-même un état utilisé dans le calcul, alors cet objet doit être considéré comme un argument implicite de l'opération. Dans ce cas, les arguments, le récepteur et le résultat devraient appartenir au même type.

Une telle opération est dite **fermée** (*closed*) sur l'ensemble des instances de ce type.

Une opération fermée fournit une interface de haut niveau tout en évitant d'introduire des dépendances vers d'autres concepts.

Ce pattern s'applique particulièrement bien aux **Objets Valeur**.

Pour les Entités, la situation est différente. Leur identité et leur cycle de vie ont une importance métier. On ne peut généralement pas créer arbitrairement une nouvelle Entité comme résultat d'un calcul.

Certaines opérations peuvent néanmoins être fermées sur des Entités. Par exemple :

```
Employee → Supervisor → Employee
```

Un employé peut retourner un autre employé représentant son responsable.

Cependant, dans la majorité des cas, les Entités ne sont pas les résultats naturels d'un calcul.

C'est pourquoi ce pattern trouve généralement sa meilleure expression dans les Objets Valeur.

Il existe également des situations intermédiaires :

- l'argument et le récepteur sont du même type mais le résultat est différent ;
- le résultat est du même type que le récepteur mais les arguments sont différents.

Ces opérations ne sont pas totalement fermées, mais elles conservent une partie des avantages de la fermeture en simplifiant le raisonnement.

------

# Interprétation en DDD

Ce pattern est probablement l'un des plus mathématiques du livre d'Eric Evans.

Son idée fondamentale est pourtant très simple :

> **Un concept métier devient plus facile à manipuler lorsqu'il produit des résultats exprimés dans son propre langage.**

------

## Une analogie mathématique

En mathématiques :

```
3 + 5 = 8
```

L'opération :

```
Nombre + Nombre → Nombre
```

est fermée.

Le résultat reste dans le même univers conceptuel.

On peut alors enchaîner les opérations :

```
(3 + 5) + 7
```

sans jamais sortir du concept de « nombre ».

------

Evans cherche exactement la même propriété dans le modèle métier.

------

# Exemple classique : Money

Considérons un Objet Valeur :

```
Money
```

Une opération fermée serait :

```
Money total =
    amount.Add(tax);
```

Nous obtenons :

```
Money + Money → Money
```

Le résultat reste un concept métier.

On peut poursuivre :

```
Money final =
    amount
        .Add(tax)
        .Add(discount);
```

Le langage reste cohérent.

------

## Exemple dans votre domaine de réservation de sièges

Imaginons :

```
SeatNumber
```

Une opération fermée pourrait être :

```
SeatNumber next =
    seat.Next();
```

ou :

```
SeatNumber shifted =
    seat.OffsetBy(3);
```

Nous obtenons :

```
SeatNumber → SeatNumber
```

Le résultat reste dans le même univers conceptuel.

------

Même chose pour :

```
Distance
Distance total =
    leftDistance.Add(rightDistance);
```

Nous avons :

```
Distance + Distance → Distance
```

La fermeture est conservée.

------

# Pourquoi Evans apprécie cette propriété

Lorsqu'une opération retourne un type primitif :

```
decimal CalculatePrice();
```

une partie du sens métier disparaît.

Le résultat :

```
decimal
```

peut représenter :

- un prix ;
- un taux ;
- une quantité ;
- une distance.

Le modèle devient moins expressif.

------

À l'inverse :

```
Money CalculatePrice();
```

préserve le langage du domaine.

Le résultat reste un concept métier.

------

# Le lien avec les Value Objects

Evans indique explicitement :

> Recherchez principalement ce pattern dans les Objets Valeur.

Pourquoi ?

Parce que les Objets Valeur :

- sont immuables ;
- représentent des concepts ;
- sont souvent le résultat de calculs.

Par exemple :

```
Money
Distance
Percentage
ExchangeRate
DateRange
Temperature
```

sont naturellement adaptés aux opérations fermées.

------

# Exemple de votre atelier Seating

Supposons :

```
SeatingWeight
```

représentant le poids d'un groupe de sièges.

On pourrait écrire :

```
SeatingWeight total =
    leftWeight.Add(rightWeight);
```

Le résultat reste :

```
SeatingWeight
```

Le modèle reste homogène.

------

À l'inverse :

```
double ComputeWeight(...)
```

fait immédiatement perdre une partie du sens métier.

------

# Les bénéfices du Supple Design

## 1. Réduction des dépendances

Une opération fermée ne nécessite pas l'introduction de nouveaux concepts.

```
Money
  ↓
Money
```

au lieu de :

```
Money
  ↓
decimal
  ↓
Conversion
  ↓
Autre concept
```

------

## 2. Composition naturelle

Les opérations deviennent chaînables :

```
price
    .Add(tax)
    .Subtract(discount)
    .Apply(exchangeRate);
```

Chaque étape produit le même concept.

------

## 3. Langage métier préservé

Le développeur continue de raisonner avec :

```
Money
Distance
SeatNumber
DateRange
```

plutôt qu'avec :

```
decimal
int
double
string
```

------

# Une lecture moderne

Ce pattern se retrouve aujourd'hui dans de nombreux modèles riches :

### Money

```
Money + Money → Money
```

### DateRange

```
DateRange ∩ DateRange → DateRange
```

### Vector

```
Vector + Vector → Vector
```

### SeatNumber

```
SeatNumber + Offset → SeatNumber
```

Toutes ces opérations préservent le concept métier.

------

# Le message fondamental d'Eric Evans

Une opération fermée permet de rester dans le même univers conceptuel avant et après le calcul.

On peut résumer ce pattern ainsi :

```
Concept métier
       ↓
Opération
       ↓
Même concept métier
```

ou encore :

```
Money
   + Money
       ↓
Money
```

Cette propriété semble anodine, mais elle contribue fortement au **Supple Design** : elle réduit la charge cognitive, préserve le Langage Ubiquitaire et permet de construire des modèles plus expressifs, plus composables et plus élégants. C'est l'une des raisons pour lesquelles les Objets Valeur occupent une place si importante dans le Domain-Driven Design.

# Conception déclarative (Declarative Design)

Dans un logiciel procédural classique, il n'existe jamais de véritables garanties.

Même lorsqu'une opération semble respecter certaines règles, rien n'empêche qu'elle produise des effets secondaires supplémentaires qui n'ont pas été explicitement interdits.

Aussi orientée métier soit-elle, une conception reste généralement traduite en procédures destinées à produire les effets correspondant aux interactions conceptuelles du domaine.

Une grande partie du code écrit au quotidien consiste alors en :

- du code de plomberie ;
- du code de coordination ;
- du code répétitif ;

qui n'apporte ni sens métier ni comportement significatif.

Les interfaces révélatrices d'intention, les fonctions sans effet de bord et les assertions améliorent considérablement la situation, mais elles ne confèrent jamais à elles seules une rigueur formelle aux programmes orientés objet traditionnels.

------

## Pourquoi une conception déclarative ?

La conception déclarative cherche à résoudre ce problème.

Le terme *déclaratif* possède plusieurs significations selon les contextes, mais l'idée générale est la suivante :

> Écrire tout ou partie du logiciel comme une spécification exécutable.

Plutôt que de décrire précisément comment réaliser une action, on décrit les propriétés attendues ou les règles à respecter.

Cette description devient alors le moteur du comportement du système.

Selon les technologies utilisées, cela peut être réalisé :

- par réflexion (*reflection*) ;
- par génération de code ;
- par interprétation de métadonnées ;
- par un moteur de règles ;
- par un DSL (Domain Specific Language).

Dans tous les cas, le logiciel exécute directement une description du comportement attendu.

Un autre développeur peut alors prendre cette déclaration au pied de la lettre :

> La spécification devient la garantie.

------

## Les limites

Les approches déclaratives peuvent néanmoins être contournées.

Si le framework :

- est difficile à utiliser ;
- impose trop de contraintes ;
- manque de flexibilité ;

les développeurs chercheront naturellement à le contourner.

Or une conception déclarative n'apporte ses bénéfices que si l'ensemble de l'équipe respecte les règles du modèle.

------

# Un style de conception déclaratif

Evans souligne ensuite une idée particulièrement intéressante :

> Une équipe n'a pas besoin d'utiliser un langage déclaratif pour bénéficier d'une conception déclarative.

Lorsqu'un modèle possède :

- des Interfaces Révélatrices d'Intention ;
- des Fonctions Sans Effet de Bord ;
- des Assertions explicites ;

il commence déjà à adopter un style déclaratif.

------

Les bénéfices apparaissent dès lors que les composants :

- sont combinables ;
- expriment clairement leur signification ;
- possèdent des effets explicites ;
- ou ne possèdent aucun effet observable.

Le code devient progressivement une description du domaine plutôt qu'une suite d'instructions techniques.

------

# Interprétation en DDD

Cette section constitue l'aboutissement logique du **Supple Design**.

Tous les patterns précédents convergent vers une même ambition :

> Faire en sorte que le code ressemble davantage à une description du métier qu'à une procédure informatique.

------

## Le code impératif

Prenons un exemple classique.

```
var availableSeats = repository.GetAvailableSeats();

var adjacentSeats =
    adjacencyAlgorithm.FindAdjacentSeats(
        availableSeats);

var bestSeats =
    weightAlgorithm.SelectBestSeats(
        adjacentSeats);

reservation.Assign(bestSeats);
```

Ce code explique :

> comment le système fonctionne.

Il expose :

- les algorithmes ;
- les étapes ;
- les mécanismes.

------

## Le code déclaratif

Avec un modèle plus riche :

```
reservation.AssignBestAdjacentSeatsFor(party);
```

Le code exprime désormais :

> ce que l'on veut obtenir.

Le détail du calcul disparaît derrière le modèle.

Le langage métier devient la structure dominante.

------

# Le lien avec votre atelier de réservation de sièges

Votre exemple de recherche de sièges adjacents illustre parfaitement cette idée.

Une première version pourrait ressembler à :

```
SortSeats();
FilterUnavailableSeats();
FindAdjacentGroups();
CalculateWeights();
SelectBestGroup();
```

Nous décrivons l'algorithme.

------

Une version plus déclarative pourrait être :

```
SeatingOffer offer =
    seatingPolicy.OfferAdjacentSeatsFor(party);
```

ou :

```
reservation.AssignBestAvailableSeats();
```

Nous décrivons l'intention métier.

Le lecteur comprend immédiatement le besoin sans connaître la mécanique.

------

# Pourquoi les patterns précédents sont nécessaires

Evans montre ici que chaque pattern du Supple Design prépare le terrain.

### Intention-Revealing Interfaces

Permettent de décrire le métier.

```
OfferAdjacentSeats
```

plutôt que :

```
ExecuteSeatAlgorithm
```

------

### Side-Effect-Free Functions

Permettent de composer les comportements.

```
Entrée
 ↓
Calcul
 ↓
Résultat
```

------

### Assertions

Permettent de faire confiance aux abstractions.

```
Je sais ce que la méthode garantit.
```

------

### Closure of Operations

Permettent de conserver le langage métier après chaque opération.

```
Money + Money → Money
```

------

### Standalone Classes

Réduisent la charge cognitive.

------

Une fois ces éléments réunis, le code devient naturellement plus déclaratif.

------

# Le lien avec les DSL

Cette idée conduira plus tard à de nombreuses pratiques modernes :

- Specification Pattern ;
- DSL métier ;
- Rule Engines ;
- BDD ;
- Event Storming ;
- Langages de requêtes métier ;
- Architectures orientées événements.

Toutes poursuivent le même objectif :

> Rendre le métier visible dans le code.

------

# Une lecture moderne

Aujourd'hui, lorsqu'une équipe DDD produit du code comme :

```
reservation.Confirm();
trade.Validate();
position.Reconcile();
payment.Authorize();
```

elle pratique déjà une forme de conception déclarative.

Le code ressemble davantage à un document métier qu'à une procédure technique.

------

# Le message fondamental d'Eric Evans

La conception déclarative n'est pas d'abord une technologie.

C'est une manière de penser le logiciel.

On peut résumer cette idée ainsi :

```
Code procédural
    ↓
Comment faire ?

Code déclaratif
    ↓
Que veut-on obtenir ?
```

Ou encore :

```
Supple Design
       ↓
Modèle profond
       ↓
Intentions explicites
       ↓
Code lisible comme une spécification
```

La conception déclarative représente ainsi l'aboutissement du Supple Design : un logiciel dans lequel le code exprime directement le domaine métier, au point de devenir une forme de spécification exécutable.

# S'appuyer sur des formalismes établis (Drawing on Established Formalisms)

Créer à partir de zéro un cadre conceptuel rigoureux et cohérent est une tâche difficile.

Il arrive parfois qu'une équipe découvre et affine progressivement un tel cadre au cours d'un projet. Cependant, il est souvent plus efficace de s'appuyer sur des systèmes conceptuels déjà existants.

Dans de nombreux domaines, ces systèmes ont été :

- élaborés ;
- raffinés ;
- simplifiés ;

pendant des décennies, voire des siècles.

Par exemple, de nombreuses applications métier manipulent des concepts comptables.

La comptabilité fournit déjà :

- des Entités ;
- des règles ;
- des invariants ;
- un vocabulaire précis ;

qui peuvent être directement réutilisés pour construire un modèle profond et un design souple.

Il existe de nombreux formalismes de ce type.

Le favori d'Evans est sans doute :

> **les mathématiques.**

Même une simple variation autour de notions arithmétiques élémentaires peut parfois révéler une modélisation extrêmement élégante.

De nombreux domaines contiennent des structures mathématiques implicites.

Il faut les rechercher, les mettre en évidence et les exploiter.

Les mathématiques spécialisées possèdent plusieurs propriétés particulièrement intéressantes :

- elles sont précises ;
- elles sont composables ;
- elles reposent sur des règles explicites ;
- elles sont souvent faciles à comprendre lorsqu'elles sont correctement introduites.

Dans le livre *Domain-Driven Design*, Evans illustre cette idée à travers un exemple réel appelé **Shares Math**, présenté dans le chapitre 8.

------

# Interprétation en DDD

Cette section constitue probablement l'une des idées les plus profondes du livre.

Evans suggère ici que :

> **Les meilleurs modèles ne sont pas toujours inventés. Ils sont souvent découverts.**

------

## Le piège du logiciel

Face à un problème métier, les développeurs ont tendance à inventer :

```
Manager
Processor
Helper
Service
Engine
```

et à construire progressivement un système technique.

Pour Evans, cette approche passe souvent à côté de la véritable structure du domaine.

Il invite plutôt à se demander :

> **Existe-t-il déjà un modèle conceptuel mature décrivant ce problème ?**

------

# L'exemple de la comptabilité

La comptabilité existe depuis plusieurs siècles.

Elle possède déjà :

```
Compte
Journal
Écriture
Débit
Crédit
Balance
```

Ces concepts sont :

- rigoureusement définis ;
- compris par les experts ;
- accompagnés d'invariants.

Par exemple :

```
Somme des débits
=
Somme des crédits
```

Cette règle n'est pas une invention du logiciel.

Elle existe déjà dans le domaine.

Le rôle du développeur consiste à l'exprimer.

------

# Pourquoi Evans aime les mathématiques

Les mathématiques possèdent exactement les qualités recherchées par le Supple Design.

## Précision

Un concept mathématique possède une définition claire.

```
Pourcentage
Distance
Vecteur
Taux
Intervalle
```

------

## Composition

Les opérations sont naturellement combinables.

```
Money + Money → Money
Distance + Distance → Distance
```

Nous retrouvons ici directement le pattern :

> **Closure of Operations**

------

## Faible ambiguïté

Lorsque deux personnes parlent d'une addition :

```
10 + 5
```

elles obtiennent le même résultat.

Les interprétations divergentes sont limitées.

------

# Exemple dans votre atelier de réservation de sièges

Votre exercice autour des sièges adjacents constitue un excellent exemple.

Une première approche consiste à raisonner en termes techniques :

```
Liste
Boucle
Tri
Filtre
Algorithme
```

------

Une approche plus formalisée consiste à découvrir des concepts métier comme :

```
DistanceFromCenter
AdjacentSeatGroup
SeatingWeight
```

Ces concepts possèdent presque une nature mathématique.

Par exemple :

```
Poids d'un groupe
=
Somme des distances
```

Cette formulation devient :

- plus précise ;
- plus composable ;
- plus testable.

------

# Exemple dans la finance

Compte tenu de votre expérience chez Natixis, SG ou BNP, vous avez probablement rencontré ce phénomène à plusieurs reprises.

Les marchés financiers reposent déjà sur des formalismes établis :

```
Yield
Duration
Convexity
DV01
NPV
```

Un mauvais modèle tenterait de réinventer ces concepts.

Un bon modèle les reprend tels quels.

------

Par exemple :

```
Money
InterestRate
Duration
```

sont beaucoup plus riches que :

```
decimal
decimal
decimal
```

Le langage du domaine devient visible.

------

# Le lien avec le Deep Modeling

Cette section complète parfaitement la notion de Deep Model.

Un modèle profond n'est pas forcément :

```
Nouveau
```

Il peut être :

```
Découvert
```

à partir :

- d'une discipline métier ;
- d'une théorie existante ;
- d'un cadre conceptuel ancien.

Evans encourage les équipes à explorer :

```
Comptabilité
Mathématiques
Logistique
Assurance
Physique
Statistiques
```

et tout autre domaine susceptible d'apporter des concepts robustes.

------

# Le lien avec le Supple Design

Les formalismes établis produisent souvent naturellement :

### Des Objets Valeur

```
Money
Percentage
Distance
DateRange
```

------

### Des opérations fermées

```
Money + Money → Money
```

------

### Des invariants

```
Débit = Crédit
```

------

### Des interfaces révélatrices d'intention

```
price.ApplyDiscount(rate);
```

plutôt que :

```
Calculate(decimal value);
```

------

Ils favorisent donc simultanément :

```
Deep Modeling
+
Supple Design
```

------

# Une lecture moderne

Aujourd'hui, cette idée est au cœur de nombreux succès du DDD.

Les meilleurs modèles s'appuient souvent sur des formalismes existants :

| Domaine            | Formalisme                   |
| ------------------ | ---------------------------- |
| Finance            | Mathématiques financières    |
| Logistique         | Théorie des flux             |
| Télécommunications | Théorie des réseaux          |
| Assurance          | Actuariat                    |
| Commerce           | Comptabilité                 |
| Géolocalisation    | Géométrie et graphes         |
| IA                 | Probabilités et statistiques |

Les équipes les plus efficaces ne réinventent pas ces concepts.

Elles les découvrent puis les intègrent au modèle.

------

# Le message fondamental d'Eric Evans

Lorsque vous cherchez un modèle profond, ne partez pas systématiquement d'une feuille blanche.

Cherchez d'abord :

> **Quels systèmes conceptuels ont déjà résolu une partie de ce problème ?**

On peut résumer ce pattern ainsi :

```
Formalismes établis
        ↓
Concepts éprouvés
        ↓
Modèle plus profond
        ↓
Design plus souple
```

Ou encore :

```
Ne réinventez pas les concepts.
Découvrez-les.
```

C'est probablement l'un des conseils les plus puissants d'Evans : les meilleurs modèles émergent souvent lorsque l'on révèle la structure cachée du domaine plutôt que lorsque l'on tente d'en inventer une nouvelle.

# Contours conceptuels (Conceptual Contours)

Certaines équipes découpent les fonctionnalités en très petits éléments afin de favoriser leur réutilisation et leur combinaison.

D'autres préfèrent regrouper les responsabilités dans des composants plus larges afin de masquer la complexité.

D'autres encore cherchent à maintenir une granularité uniforme, avec des classes et des opérations de taille comparable.

Ces approches sont des simplifications excessives. Elles ne constituent pas de bonnes règles générales.

Elles tentent néanmoins de répondre à un problème réel :

> Où faut-il placer les frontières du modèle ?

------

Lorsque plusieurs concepts sont enfermés dans une construction monolithique :

- les responsabilités se mélangent ;
- certaines fonctionnalités se retrouvent dupliquées ;
- l'intention devient difficile à comprendre ;
- l'interface publique ne reflète plus clairement les concepts sous-jacents.

Le sens du modèle devient flou parce que plusieurs idées distinctes cohabitent dans le même élément.

------

À l'inverse, un découpage excessif produit d'autres problèmes.

Lorsque les classes ou les méthodes sont fragmentées à l'extrême :

- le client doit comprendre comment assembler les morceaux ;
- la complexité est déplacée vers l'extérieur ;
- les concepts métier peuvent disparaître.

Evans utilise une image frappante :

> La moitié d'un atome d'uranium n'est plus de l'uranium.

Autrement dit :

> Certains concepts n'ont de sens que lorsqu'ils sont considérés comme un tout cohérent.

Le problème n'est donc pas uniquement la taille des éléments, mais surtout l'endroit où passent les frontières.

------

## Par conséquent

Décomposez les éléments du design :

- opérations ;
- interfaces ;
- classes ;
- agrégats ;

en unités cohérentes.

Pour cela, appuyez-vous sur votre intuition des divisions importantes du domaine.

Au fil des refactorings, observez :

- ce qui change ensemble ;
- ce qui reste stable ;
- les zones de tension récurrentes.

Cherchez les contours conceptuels sous-jacents qui expliquent ces mouvements.

Alignez ensuite le modèle sur les structures naturelles du domaine.

Un Supple Design fondé sur un Deep Model produit alors :

- des interfaces simples ;
- des concepts cohérents ;
- des combinaisons naturelles dans le Langage Ubiquitaire ;
- peu d'options inutiles ;
- peu de complexité accidentelle.

------

# Interprétation en DDD

Cette section est probablement l'une des plus profondes du chapitre sur le **Supple Design**.

Elle traite d'un sujet qui préfigure directement :

- les Bounded Contexts ;
- les Agrégats ;
- les Modules ;
- Team Topologies ;
- la charge cognitive.

La question centrale est :

> **Où passent naturellement les frontières du domaine ?**

------

# Le faux débat de la granularité

Les développeurs débattent souvent :

```
Faut-il de grosses classes ?
```

ou :

```
Faut-il de petites classes ?
```

Pour Evans, ce n'est pas la bonne question.

La vraie question est :

> **Le découpage suit-il les contours naturels du domaine ?**

------

## Mauvais découpage : tout dans une seule classe

Imaginons :

```
ReservationManager
```

qui gère :

- les sièges ;
- la tarification ;
- les paiements ;
- les billets ;
- les notifications.

Nous obtenons :

```
Plusieurs concepts
      ↓
Une seule classe
```

Le modèle devient difficile à comprendre.

------

## Mauvais découpage : fragmentation excessive

À l'inverse :

```
SeatFinder
SeatValidator
SeatWeightCalculator
SeatSorter
SeatSelector
SeatProcessor
```

Le client doit connaître :

- les étapes ;
- leur ordre ;
- leurs interactions.

Le concept métier :

```
Attribuer les meilleurs sièges
```

a disparu.

------

# Les contours naturels du domaine

Evans nous invite à rechercher les unités de sens.

Dans votre atelier de réservation de sièges, on observe naturellement :

```
Seat
SeatGroup
Party
SeatingOffer
```

Ces concepts possèdent une cohérence propre.

Ils forment des contours naturels.

------

# Observer les axes de changement

C'est probablement l'idée la plus importante du texte.

Evans recommande d'observer :

```
Ce qui change ensemble
```

et :

```
Ce qui reste stable
```

------

Supposons :

```
Les règles tarifaires changent souvent
```

mais :

```
La notion de réservation reste stable
```

Cette observation suggère peut-être :

```
Reservation
```

et :

```
Pricing Policy
```

comme deux concepts distincts.

------

Les refactorings deviennent alors un outil de découverte.

Chaque fois qu'un changement devient difficile :

```
Pourquoi ces éléments doivent-ils évoluer ensemble ?
```

La réponse révèle souvent un contour conceptuel.

------

# Le lien avec les Agrégats

Quelques chapitres plus tôt, Evans introduit :

```
Aggregate
```

Les Agrégats sont eux-mêmes des contours conceptuels.

Ils regroupent :

```
Ce qui doit rester cohérent ensemble
```

et séparent :

```
Ce qui peut évoluer indépendamment
```

------

Dans votre exemple :

```
Reservation
```

forme probablement un Agrégat.

Tandis que :

```
Performance
```

ou :

```
Customer
```

peuvent évoluer séparément.

------

# Le lien avec les Bounded Contexts

Cette idée réapparaît ensuite à une échelle plus grande.

Un Bounded Context représente lui aussi :

```
Un contour conceptuel
```

mais à l'échelle :

- d'une équipe ;
- d'un sous-domaine ;
- d'un modèle complet.

On retrouve exactement le même raisonnement :

```
Classe
      ↓
Agrégat
      ↓
Module
      ↓
Bounded Context
```

À chaque niveau, la question reste :

> Où passe naturellement la frontière ?

------

# Le lien avec Team Topologies

Cette section est particulièrement intéressante au regard de vos travaux récents.

Lorsque Evans écrit :

> Observer les axes de changement et de stabilité

il anticipe presque directement la notion moderne de :

> **Charge cognitive**

Les équipes efficaces sont généralement alignées sur des contours conceptuels stables.

Autrement dit :

```
Un problème cohérent
      ↓
Une équipe
```

plutôt que :

```
Plusieurs problèmes hétérogènes
      ↓
Une seule équipe
```

------

# Exemple dans vos travaux sur les Bounded Contexts

Vous utilisez souvent la formulation :

> Une équipe doit être capable de comprendre collectivement le problème métier qu'elle porte.

Cette idée est exactement celle des contours conceptuels.

Lorsque le contour devient trop vaste :

```
Charge cognitive excessive
```

Le modèle suggère souvent naturellement :

```
Découpage
```

en plusieurs espaces de cohérence.

------

# Une lecture moderne

Aujourd'hui, cette idée apparaît sous différentes formes :

- Bounded Context ;
- Agrégat ;
- Modular Monolith ;
- Team Topologies ;
- Strategic Design ;
- Microservices.

Toutes reposent finalement sur la même intuition :

> Les frontières techniques doivent suivre les frontières conceptuelles.

------

# Le message fondamental d'Eric Evans

Les meilleurs découpages ne proviennent ni d'une règle de taille, ni d'une convention technique.

Ils émergent des formes naturelles du domaine.

On peut résumer ce pattern ainsi :

```
Refactorings successifs
          ↓
Observation des changements
          ↓
Découverte des contours
          ↓
Alignement du modèle
```

Ou encore :

```
Ne découpez pas selon la technique.
Découpez selon le sens.
```

Les **Contours Conceptuels** représentent ainsi l'un des ponts les plus importants entre le **Deep Modeling** et le **Strategic Design** : ils permettent de découvrir où résident réellement les unités de cohérence du domaine, celles qui deviendront demain des classes, des agrégats, des modules ou même des Bounded Contexts.

# Framework de composants enfichables (Pluggable Component Framework)

Certaines opportunités n'apparaissent que lorsque le modèle de domaine a atteint un haut niveau de maturité.

Un modèle :

- profond ;
- raffiné ;
- distillé ;

finit parfois par révéler un noyau conceptuel suffisamment stable pour être partagé entre plusieurs applications.

Un framework de composants enfichables n'apparaît généralement qu'après que plusieurs applications ont déjà été développées dans le même domaine.

------

Lorsque plusieurs applications doivent collaborer tout en ayant été conçues indépendamment, elles reposent souvent sur des abstractions similaires mais implémentées différemment.

Dans cette situation :

- les traductions entre Bounded Contexts se multiplient ;
- l'intégration devient coûteuse ;
- les redondances apparaissent ;
- les concepts se fragmentent.

------

La solution du Shared Kernel n'est pas toujours envisageable.

En effet, elle suppose généralement :

- une collaboration étroite ;
- une gouvernance commune ;
- une synchronisation fréquente entre équipes.

Lorsque les équipes sont autonomes ou distribuées, cette approche devient difficile à maintenir.

------

Les conséquences sont connues :

- duplication du code ;
- duplication des modèles ;
- augmentation des coûts de développement ;
- difficultés d'installation ;
- interopérabilité limitée.

------

## Par conséquent

Identifiez et extrayez un noyau abstrait constitué :

- d'interfaces ;
- de contrats ;
- d'interactions essentielles.

Construisez ensuite un framework permettant de substituer librement différentes implémentations de ces interfaces.

Toute application respectant ce noyau abstrait doit pouvoir :

- consommer les composants ;
- remplacer une implémentation ;
- intégrer de nouveaux composants ;

sans dépendre de leur implémentation concrète.

La seule règle est :

> Les applications doivent interagir exclusivement à travers les interfaces du noyau abstrait.

------

# Interprétation en DDD

Cette section est souvent méconnue car elle apparaît à la fin du chapitre sur le Supple Design.

Pourtant, elle est particulièrement visionnaire.

Evans décrit ici une situation qui préfigure :

- les plateformes produit ;
- les architectures à plugins ;
- les frameworks métiers ;
- les plateformes internes (*Internal Developer Platforms*) ;
- les architectures hexagonales ;
- certains aspects des microservices modernes.

------

# L'idée fondamentale

Après plusieurs années d'évolution, un domaine finit parfois par révéler :

```
Ce qui varie
```

et :

```
Ce qui reste stable
```

Le noyau stable devient alors un candidat naturel à l'abstraction.

------

# Exemple simple : paiements

Supposons plusieurs applications :

```
Site e-commerce
Application mobile
Back-office
CRM
```

Toutes doivent encaisser un paiement.

Au lieu d'avoir :

```
StripePaymentService
PayPalPaymentService
AdyenPaymentService
```

dans chaque application, le domaine peut faire émerger :

```
IPaymentProcessor
```

------

Puis :

```
StripePaymentProcessor
AdyenPaymentProcessor
PayPalPaymentProcessor
```

------

Le concept métier :

```
Traiter un paiement
```

devient stable.

L'implémentation devient interchangeable.

------

# Le lien avec le Deep Modeling

Ce pattern n'est possible que lorsque le modèle a été suffisamment distillé.

Avant cela, les équipes ne savent pas encore :

```
Quels concepts sont fondamentaux
```

ni :

```
Quels concepts sont accidentels
```

------

C'est pourquoi Evans écrit :

> « Opportunities arise in a very mature model »

Autrement dit :

> Ce pattern est une conséquence du Deep Modeling.

------

# Le lien avec votre contexte DDD

Cette idée est particulièrement intéressante dans vos travaux sur :

- BPCE / Natixis ;
- modernisation de systèmes legacy ;
- plateformes de trading ;
- architectures par Bounded Context.

------

Prenons l'exemple de TRAFIC.

Après plusieurs années, certains concepts deviennent extrêmement stables :

```
Position
Trade
Instrument
PnL
```

------

Différentes applications peuvent alors partager :

```
IPositionProvider
ITradeRepository
IPnLCalculator
```

sans partager les implémentations.

------

Le framework devient :

```
Un langage commun
```

plus qu'une bibliothèque technique.

------

# Le lien avec l'Architecture Hexagonale

On retrouve ici presque exactement le principe :

```
Ports
      ↓
Adaptateurs
```

Le noyau abstrait correspond aux ports.

Les implémentations deviennent des adaptateurs interchangeables.

```
Application
      ↓
Port
      ↓
Adaptateur
```

------

Par exemple :

```
ITradeFeed
```

peut être implémenté par :

```
ReutersFeed
```

ou :

```
BloombergFeed
```

ou :

```
MockTradeFeed
```

------

# Le lien avec les plateformes internes

Cette idée est aujourd'hui au cœur des plateformes d'entreprise.

Une plateforme moderne expose :

```
Contrats
Interfaces
Événements
API
```

et laisse les équipes développer leurs propres implémentations.

------

Dans Team Topologies, cela ressemble fortement à une :

```
Platform Team
```

qui fournit :

```
Un ensemble de capacités réutilisables
```

sans imposer une implémentation unique.

------

# Attention au piège

Evans ne recommande pas de construire un framework générique dès le début.

C'est probablement l'erreur la plus fréquente.

Beaucoup d'équipes tentent de créer :

```
Le framework universel
```

avant même d'avoir compris le domaine.

------

Le résultat est souvent :

```
Abstractions prématurées
Complexité
Rigidité
```

------

Pour Evans :

```
Plusieurs applications
        ↓
Plusieurs implémentations
        ↓
Concepts stables identifiés
        ↓
Distillation
        ↓
Framework
```

et non l'inverse.

------

# Une lecture moderne

Aujourd'hui, on retrouve ce pattern dans :

- les SDK métiers ;
- les plateformes cloud internes ;
- les frameworks de paiement ;
- les moteurs de règles ;
- les systèmes de plugins ;
- les plateformes événementielles ;
- les Design Systems côté Front-End.

Tous reposent sur le même principe :

> Stabiliser les concepts métier et rendre variables les implémentations.

------

# Le message fondamental d'Eric Evans

Lorsqu'un domaine a atteint un haut niveau de maturité, certains concepts deviennent suffisamment stables pour former un noyau abstrait partagé.

On peut alors résumer ce pattern ainsi :

```
Deep Model
      ↓
Distillation
      ↓
Noyau abstrait
      ↓
Interfaces stables
      ↓
Implémentations interchangeables
```

Ou encore :

```
Ne partagez pas le code.
Partagez les abstractions.
```

Le **Pluggable Component Framework** représente ainsi l'aboutissement de la distillation du modèle : un ensemble minimal de concepts essentiels, suffisamment stables pour servir de fondation à un écosystème entier d'applications tout en préservant l'autonomie des équipes et des implémentations.
