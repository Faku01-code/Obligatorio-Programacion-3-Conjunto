  
**Instituto Tecnológico CTC Rosario**

**Analista Programador**

**Ingeniería de Software**

**Sistema de Gestión de Obras**

**Pages & Familia**

Andrés Klett

**Alex Roth**

**Juan Meny**

**Facundo Villalba**

**2026**

# **Índice**

**[Índice	2](#heading=)**

[**1\.  Abstract	4**](#heading=)

[**2\.  Introducción	5**](#heading=)

[2.1  Contexto	5](#heading=)

[2.2  Objetivo del documento	5](#heading=)

[2.3  Contenido	5](#heading=)

[**3\.  Presentación del Cliente	6**](#heading=)

[3.1  ¿Quién es?	6](#heading=)

[3.2  ¿Cómo trabaja hoy?	6](#heading=)

[3.3  ¿Quiénes más están involucrados?	6](#heading=)

[**4\.  Presentación del Problema	7**](#heading=)

[4.1  ¿Cuál es el problema?	7](#heading=)

[4.2  ¿Cómo lo enfrenta hoy?	7](#heading=)

[4.3  ¿Qué consecuencias trae ese problema?	7](#heading=)

[**5\.  Actores involucrados	8**](#heading=)

[**6\.  Lista de necesidades	9**](#heading=)

[**7\.  User Stories	10**](#heading=)

[**8\.  Lista de objetivos	11**](#heading=)

[**9\.  Requerimientos funcionales y no funcionales	12**](#heading=)

[9.1  Requerimientos funcionales	12](#heading=)

[9.2  Requerimientos no funcionales	12](#heading=)

[**10\.  Elección de metodología	13**](#heading=)

[**11\. Descripción del entorno	14**](#11.-descripción-del-entorno)

[1.1 Entorno organizacional y de negocio	14](#1.1-entorno-organizacional-y-de-negocio)

[11.2 Entorno operativo	14](#11.2-entorno-operativo)

[11.3 Entorno de desarrollo	14](#11.3-entorno-de-desarrollo)

[**12\. Análisis de alternativas	15**](#12.-análisis-de-alternativas)

[12.1 Criterios de evaluación	15](#12.1-criterios-de-evaluación)

[12.2 Alternativas consideradas	15](#12.2-alternativas-consideradas)

[12.3 Comparación y decisión	16](#12.3-comparación-y-decisión)

[**13\. Estudio de factibilidad	17**](#13.-estudio-de-factibilidad)

[13.1 Factibilidad técnica	17](#13.1-factibilidad-técnica)

[13.2 Factibilidad económica	17](#13.2-factibilidad-económica)

[13.3 Factibilidad funcional	17](#13.3-factibilidad-funcional)

[13.4 Factibilidad temporal	17](#13.4-factibilidad-temporal)

[13.5 Factibilidad legal	18](#13.5-factibilidad-legal)

[13.6 Conclusión del estudio	18](#13.6-conclusión-del-estudio)

[**14\. Integrantes y roles	19**](#14.-integrantes-y-roles)

[**15\. Descripción y selección de herramientas	20**](#15.-descripción-y-selección-de-herramientas)

[**16\. Plan de aseguramiento de la calidad (SQA)	21**](#16.-plan-de-aseguramiento-de-la-calidad-\(sqa\))

[16.1 Objetivos de calidad	21](#16.1-objetivos-de-calidad)

[16.2 Estándares y convenciones	21](#16.2-estándares-y-convenciones)

[16.3 Revisiones	21](#16.3-revisiones)

[16.4 Métricas	21](#16.4-métricas)

[16.5 Gestión de defectos	22](#16.5-gestión-de-defectos)

[**17\. Plan de testing	23**](#17.-plan-de-testing)

[17.1 Niveles de prueba	23](#17.1-niveles-de-prueba)

[17.2 Tipos de prueba	23](#17.2-tipos-de-prueba)

[17.3 Estrategia por incremento	23](#17.3-estrategia-por-incremento)

[17.4 Casos de prueba (ejemplos)	24](#17.4-casos-de-prueba-\(ejemplos\))

[17.5 Criterios de aceptación	24](#17.5-criterios-de-aceptación)

[**18\. Plan de gestión de la configuración (SCM)	25**](#18.-plan-de-gestión-de-la-configuración-\(scm\))

[18.1 Ítems de configuración	25](#18.1-ítems-de-configuración)

[18.2 Control de versiones y ramas	25](#18.2-control-de-versiones-y-ramas)

[18.3 Gestión de cambios	25](#18.3-gestión-de-cambios)

[18.4 Líneas base	25](#18.4-líneas-base)

[18.5 Respaldos	25](#18.5-respaldos)

[**19\. Plan de capacitación	26**](#19.-plan-de-capacitación)

[19.1 Destinatarios	26](#19.1-destinatarios)

[19.2 Modalidad y materiales	26](#19.2-modalidad-y-materiales)

[19.3 Contenidos	26](#19.3-contenidos)

[19.4 Cronograma de capacitación	26](#19.4-cronograma-de-capacitación)

[**20\. Incrementos o iteraciones definidas	27**](#20.-incrementos-o-iteraciones-definidas)

[**21\. Cronograma de trabajo y criticidad	28**](#21.-cronograma-de-trabajo-y-criticidad)

[21.1 Cronograma	28](#21.1-cronograma)

[21.2 Análisis de criticidad	29](#21.2-análisis-de-criticidad)

[**22\. Bibliografía	30**](#22.-bibliografía)

[**23\.  Anexos	31**](#heading=)

[Anexo A) Transcripción de la entrevista	31](#heading=)

# **1\.  Abstract**

La empresa constructora Pages & Familia presenta dificultades en la gestión de la información vinculada a sus obras.

Actualmente, la organización administra sus datos mediante planillas, documentos sueltos, mensajes de texto y cuadernos físicos, lo que dificulta el acceso a información clave como el personal involucrado, los materiales requeridos y el estado de cada trabajo. Esta situación genera demoras operativas y pérdidas económicas para la empresa.

En el marco del presente documento se realiza un relevamiento inicial del cliente, su contexto y su problemática, con el objetivo de sentar las bases para el desarrollo de una solución que permita centralizar y consultar dicha información de forma ordenada y eficiente.

# **2\.  Introducción**

## **2.1  Contexto**

El sector de la construcción involucra la coordinación simultánea de personal de distintos oficios, materiales, jornadas laborales y múltiples obras en ejecución. Empresas como Pages & Familia, de tamaño chico-mediano, ejecutan proyectos variados que van desde viviendas nuevas y reformas hasta galpones y locales comerciales, contando con empleados fijos y subcontratistas según cada obra. En este tipo de organizaciones, la gestión operativa suele realizarse de forma manual y descentralizada, lo que puede generar desorden informativo, pérdida de datos y dificultades para tomar decisiones con información confiable y oportuna.

## **2.2  Objetivo del documento**

El objetivo de este documento es realizar un relevamiento inicial del cliente, comprender su contexto laboral e identificar la problemática concreta que motiva el desarrollo de una solución de software. En particular, se busca documentar cómo la empresa Pages & Familia gestiona hoy su información operativa y qué dificultades genera esa forma de trabajo en el seguimiento de obras, personal y materiales.

## **2.3  Contenido**

Este documento incluye:

* La presentación del cliente y su contexto de trabajo.

* La identificación y descripción del problema principal.

* Los actores involucrados en el sistema a desarrollar.

* La lista de necesidades y las historias de usuario (user stories).

* La lista de objetivos del proyecto.

* Los requerimientos funcionales y no funcionales.

* La elección de la metodología de trabajo.

* Los anexos, con la transcripción de la entrevista realizada al cliente.

# **3\.  Presentación del Cliente**

## **3.1  ¿Quién es?**

Pages & Familia es una empresa constructora de tamaño mediano con varios años de trayectoria en el rubro. Cuenta con un equipo de empleados fijos y, según las necesidades de cada obra, incorpora personal externo de distintos oficios: albañiles, electricistas, sanitarios, entre otros. El referente entrevistado fue Alejandro Pages, uno de los responsables de la empresa, quien aportó la visión general del negocio y describió la problemática operativa actual.

## **3.2  ¿Cómo trabaja hoy?**

La empresa desarrolla trabajos en diversas categorías: construcción de viviendas, reformas, ampliaciones, galpones y locales comerciales de pequeña y mediana escala. En cuanto a su perfil tecnológico, la organización ha gestionado históricamente la información de sus obras a través de planillas de Excel, mensajes de texto y documentos en papel. Esta modalidad genera una dispersión considerable de los datos, dificultando el acceso oportuno a información relevante.

## **3.3  ¿Quiénes más están involucrados?**

El sistema tendrá distintos perfiles dentro del trabajo de Pages & Familia. Por un lado los empleados fijos de la empresa, quienes participan de forma continua en la gestión y ejecución de las obras. Por otro lado el personal externo contratado por obra, como pueden ser albañiles, electricistas, sanitarios y otros oficios, cuya información también forma parte de los datos que hasta el día de hoy se tienen. Finalmente, la dirección o encargado de la empresa, quien es el principal interesado en acceder a la información de forma centralizada y ordenada. Cabe mencionar también la figura del cliente, es decir, el propietario o comitente que contrata los servicios de Pages & Familia. Si bien no será usuario directo del sistema, representa el actor externo cuyas obras originan toda la información que la empresa necesita gestionar.

Estas decisiones son tomadas de manera de tener una base de la cual poder partir, ya que en realidad el entrevistado menciona que el que principalmente podría llegar a utilizar el software va a ser él. De igual manera la implementación de los roles dentro del software se podrán modificar con el pasar del tiempo.

# **4\.  Presentación del Problema**

## **4.1  ¿Cuál es el problema?**

La empresa constructora Pages & Familia no cuenta con un sistema centralizado para gestionar la información operativa de sus obras. La información crítica del negocio se encuentra dispersa en múltiples medios no integrados, lo que impide al cliente acceder de forma rápida y confiable a datos sobre materiales, gastos, personal y estado de avance de cada proyecto en curso.

## **4.2  ¿Cómo lo enfrenta hoy?**

Actualmente, la empresa gestiona su información de manera completamente manual y descentralizada. Según lo indicado por el cliente, los datos de cada obra se registran en distintos soportes según la situación: algunos intercambios y acuerdos se realizan por WhatsApp, otros datos de costos o materiales se vuelcan en planillas de Excel, y parte de la información queda anotada en cuadernos o documentos físicos sueltos. No existe un proceso unificado: cada responsable registra lo que necesita en el soporte que tiene a mano en el momento. Cuando se necesita consultar información de una obra, se debe rastrear manualmente entre todos esos medios, lo que frecuentemente resulta en pérdida de tiempo o directamente en no encontrar los datos buscados.

## **4.3  ¿Qué consecuencias trae ese problema?**

Lista de los efectos concretos que tiene el problema:

* Pérdida de tiempo al tener que buscar información dispersa en múltiples medios (WhatsApp, Excel, papeles) cada vez que se necesita información.

* Imposibilidad de hacer un seguimiento claro del estado de avance de cada obra cuando se trabaja en varios proyectos de forma simultánea.

* Falta de visibilidad sobre qué materiales faltan o fueron utilizados en cada obra, lo que puede generar demoras o compras innecesarias.

* Dificultad para conocer el gasto real acumulado por obra, afectando el control presupuestario y la toma de decisiones financieras.

* Desconocimiento ágil de qué empleados están asignados a cada proyecto, complicando la organización del equipo de trabajo.

Vale destacar que la empresa lleva varios años operando de esta manera. La decisión de buscar una solución tecnológica surge de la necesidad creciente de ordenar la información a medida que la cantidad de obras simultáneas aumenta y la gestión manual se vuelve cada vez menos sostenible.

# **5\.  Actores involucrados**

A partir del relevamiento realizado se identifican los siguientes actores que interactúan, directa o indirectamente, con el sistema a desarrollar:

* Administrador (Alejandro Pages): Usuario principal y referente del sistema. Es el encargado de gestionar operativamente la empresa, controlar presupuestos, asignar personal y supervisar el progreso de las obras.

* Personal fijo y subcontratistas: Empleados y obreros de distintos oficios asignados a las obras. Su información operativa (horas, tareas, asignaciones) es gestionada dentro del sistema.

* Cliente (Propietario): Actor externo que solicita la obra. No interactúa directamente con el sistema, pero es el receptor de la información procesada cuando consulta por el estado de su proyecto.

# **6\.  Lista de necesidades**

Necesidades concretas detectadas durante la entrevista con el cliente. Cada una representa un conflicto interno actual que la solución de software deberá atender:

* Centralizar la información de las obras en un único entorno, eliminando la dependencia de mensajes, planillas y papel.

* Visualizar en tiempo real la etapa, el estado y el progreso general de múltiples obras en simultáneo.

* Registrar y ordenar los gastos e ingresos para conocer con precisión la rentabilidad (ganancias o pérdidas) de cada obra.

* Gestionar la asignación del personal, estableciendo quién trabaja en cada lugar, desde cuándo y qué tarea realiza.

* Controlar el stock y los costos de materiales para evitar compras duplicadas o gastos innecesarios.

* Implementar medidas de seguridad y control de acceso, definiendo quién puede ver o modificar la información.

* Disponer de métricas generales (horas activas, avances) para responder rápidamente a las consultas de los clientes.

# **7\.  User Stories**

A partir de las necesidades identificadas se definen las siguientes historias de usuario, las cuales describen, desde el punto de vista del actor principal, las funcionalidades esperadas del sistema:

|  | Como | Quiero | Para |
| :---- | :---- | :---- | :---- |
| **User Story 1** | Administrador | registrar una nueva obra en el sistema | centralizar su información desde el inicio y hacerle seguimiento. |
| **User Story 2** | Administrador | asignar empleados o subcontratistas a una obra | saber exactamente quién trabaja en qué proyecto y su tarea. |
| **User Story 3** | Administrador | registrar todos los gastos y pagos de una obra | poder calcular si el proyecto está dejando ganancias o pérdidas. |
| **User Story 4** | Administrador | registrar las compras y el uso de los materiales | evitar compras duplicadas y llevar un control estricto de costos. |
| **User Story 5** | Administrador | ver un panel general con el estado de todas las obras | responder de forma rápida y precisa las consultas de los clientes. |
| **User Story 6** | Administrador | configurar roles y permisos de acceso | evitar que personal no autorizado modifique la información de la empresa. |

# **8\.  Lista de objetivos**

Los objetivos del proyecto se desprenden directamente de las necesidades relevadas. Estos objetivos nos guiarán el alcance y la evaluación del éxito del sistema:

* Desarrollar y desplegar una plataforma centralizada que unifique el 100% de los registros operativos de la empresa.

* Reducir el tiempo de búsqueda de información histórica y actual a través de una base de datos estructurada.

* Proporcionar reportes financieros exactos por cada obra en ejecución y finalizada.

* Reducir las pérdidas económicas derivadas del descontrol de inventario de materiales y compras duplicadas.

# **9\.  Requerimientos funcionales y no funcionales**

Requerimientos definidos para el sistema, divididos entre los aspectos funcionales (qué debe hacer el sistema) y los no funcionales (cómo debe comportarse).

## **9.1  Requerimientos funcionales**

1. El sistema debe permitir el alta, baja, modificación y consulta (ABM) de obras, detallando su estado actual y progreso.

2. El sistema debe permitir registrar y categorizar ingresos y egresos asociados a cada proyecto.

3. El sistema debe permitir el ABM de personal interno y externo, posibilitando su asignación a una o múltiples obras con registro de fechas.

4. El sistema debe permitir la carga de materiales requeridos, su costo y registrar cuáles ya fueron adquiridos.

5. El sistema debe proporcionar un panel de control que consolide obras activas, horas totales y estado general.

6. El sistema debe incluir un módulo de gestión de usuarios, roles y permisos de acceso.

## **9.2  Requerimientos no funcionales**

1. Seguridad: El acceso debe ser protegido mediante autenticación de usuario y contraseña, limitando las acciones según el rol.

2. Usabilidad: La interfaz debe ser intuitiva y de rápida adopción, considerando que los usuarios migrarán de métodos informales (WhatsApp / papel).

3. Disponibilidad: El sistema debe tener arquitectura web para permitir la carga y consulta de datos tanto desde las oficinas como desde el lugar de obra.

4. Integridad: La base de datos debe garantizar que no existan registros huérfanos (por ejemplo, gastos asociados a obras eliminadas) y debe ser robusta frente a modificaciones concurrentes.

# **10\.  Elección de metodología**

Para la gestión y desarrollo de este proyecto se seleccionó una metodología ágil. Los motivos principales que justifican esta decisión son los siguientes:

* Adaptabilidad ante la duda: Al ser el primer acercamiento de la empresa a un sistema formal, es altamente probable que los requisitos se refinen o modifiquen al visualizar las primeras versiones del software.

* Entregas progresivas de valor: La metodología ágil permite entregar módulos funcionales en ciclos cortos, por ejemplo, comenzar con el ABM de obras y el dashboard, permitiendo al cliente validar la utilidad antes de desarrollar los módulos financieros.

* Comunicación efectiva: Reuniones semanales de revisión con el cliente (Alejandro Pages) para asegurar que el desarrollo se mantenga alineado con la solución de sus problemas.

# **11\. Descripción del entorno** {#11.-descripción-del-entorno}

## **1.1 Entorno organizacional y de negocio** {#1.1-entorno-organizacional-y-de-negocio}

Pages & Familia es una empresa constructora de tamaño chico-mediano que ejecuta varias obras en simultáneo, pudiendo ser un ejemplo de estas viviendas, reformas, ampliaciones, galpones, etc. Trabaja con personal fijo y subcontratistas según cada obra. Hoy gestiona su información de forma manual y dispersa, repartida entre planillas de Excel, mensajes de WhatsApp y anotaciones en papel, sin organización alguna. El sistema deberá expandirse en esa realidad y reemplazar esas prácticas informales.

El usuario principal será Alejandro Pages (administrador). El resto del personal aparece dentro del sistema como datos a gestionar más que como usuarios activos, y el cliente final de la obra es un actor externo que no gestiona el sistema. Esto define un entorno de uso de pocos usuarios pero con datos sensibles del negocio.

## **11.2 Entorno operativo** {#11.2-entorno-operativo}

Por requerimientos no funcionales definidos en el Hito 1, el sistema será una aplicación web, accesible tanto desde la oficina como desde el lugar de la obra. Esto determina las características del entorno de ejecución:

    • Aplicación accesible mediante navegador web (Chrome, Edge, Firefox), tanto desde computadoras de escritorio como desde dispositivos móviles.

    • Servidor de aplicación y base de datos relacional alojados en un servicio de hosting, con acceso a través de Internet.

    • La conectividad deberá contemplarse como variable, ya que en oficina la conexión es estable, pero en obra puede ser de menor calidad, lo que obliga a diseñar interfaces livianas.

    • El volumen de datos es moderado y de crecimiento progresivo, en base a una empresa pequeña, pero con necesidad de unificación y respaldo de la información.

## **11.3 Entorno de desarrollo** {#11.3-entorno-de-desarrollo}

El desarrollo se realiza en el transcurso de la materia, con el equipo de los estudiantes Juan Meny, Alex Roth y Facundo Villalba, utilizando herramientas gratuitas y/o de uso académico. El equipo trabaja de forma distribuida, coordinando mediante reuniones periódicas y un repositorio compartido de código. Las herramientas que componen este entorno se detallan en el punto 5 (Descripción y selección de herramientas).

# **12\. Análisis de alternativas** {#12.-análisis-de-alternativas}

Antes de comenzar a desarrollar una solución conviene comparar las opciones disponibles. El análisis de alternativas forma parte del estudio inicial del proyecto y nos permite justificar técnicamente la decisión elegida en vez de darla por sentada y avanzar con la construcción.

## **12.1 Criterios de evaluación** {#12.1-criterios-de-evaluación}

Las alternativas se evaluaron según los siguientes criterios, derivados de las necesidades del cliente: ajuste a los requerimientos relevados, costo de adquisición y mantenimiento, curva de aprendizaje para el usuario, capacidad de adaptación a futuros cambios y viabilidad dentro del marco académico del proyecto.

## **12.2 Alternativas consideradas** {#12.2-alternativas-consideradas}

| Alternativa | Descripción | Ventajas | Desventajas |
| ----- | ----- | ----- | ----- |
| A. Mantener el método actual | Seguir usando Excel, WhatsApp y papel. | Costo nulo, nada nuevo que aprender. | No resuelve el problema, persiste la mala organización y la pérdida de información. |
| B. Software comercial, ERP de construcción | Contratar una solución de pago por suscripción. | Funcionalidad amplia y probada, soporte del proveedor. | Costo recurrente alto, funciones de más, poco ajuste al modo de trabajo de la empresa, dependencia externa.  |
| C. Herramientas genéricas mejoradas | Plantillas de planillas en la nube compartidas y ordenadas. | Bajo costo, familiaridad del usuario. | No unifica realmente, sin control de acceso ni integridad, difícil de hacer escalable.  |
| D. Desarrollo a medida (elegida) | Aplicación web propia construida según los requerimientos. | Ajuste total a la necesidad, control sobre seguridad y evolución, valor académico. | Requiere esfuerzo de desarrollo y mantenimiento por parte de nuestro equipo. |

## **12.3 Comparación y decisión** {#12.3-comparación-y-decisión}

La alternativa A se descarta totalmente porque es justamente el problema a resolver. La alternativa B ofrece potencia pero a un costo y con una dificultad bastante elevada para una empresa pequeña que recién se acerca a un sistema formal. La alternativa C es una mejora parcial que no aporta unificación real ni control de la información realmente. La alternativa D, el desarrollo a medida, es la que mejor encaja con el ajuste a los requerimientos, el control sobre la seguridad y la posibilidad de evolucionar el producto, además de ser coherente con los objetivos de la materia. Por estos motivos se selecciona el desarrollo a medida de una aplicación web.

# **13\. Estudio de factibilidad** {#13.-estudio-de-factibilidad}

El estudio de factibilidad responde a si vale la pena y es posible llevar adelante el proyecto. Se puede decir que es como un primer filtro dentro de la ingeniería de requerimientos. Se analizan las siguientes partes: parte técnica, económica, funcional, temporal y, sobre todo, legal.

## **13.1 Factibilidad técnica** {#13.1-factibilidad-técnica}

El sistema es técnicamente viable, ya que se trata de una aplicación web de gestión (ABM, consultas, reportes y control de acceso), la cual utiliza tecnologías establecidas y documentadas. El equipo cuenta con los conocimientos de programación, bases de datos y desarrollo web adquiridos en la carrera. Dichos conocimientos son suficientes para abordar un sistema de este nivel.

## **13.2 Factibilidad económica** {#13.2-factibilidad-económica}

En el contexto académico de la carrera, el costo de desarrollo se cubre con el trabajo del equipo y equipos propios, y las herramientas seleccionadas son gratuitas. Para el cliente, el beneficio esperado es la reducción del tiempo perdido buscando información, la disminución de compras duplicadas de materiales y un mejor control de la rentabilidad por obra. El análisis de beneficio resulta favorable, ya que el esfuerzo de construcción se compensa con ahorros concretos para la empresa Pages & Familia.

## **13.3 Factibilidad funcional** {#13.3-factibilidad-funcional}

El sistema apunta a resolver un problema real y reconocido por el propio cliente, lo que reduce la resistencia al cambio. El principal riesgo funcional es la usabilidad: si la herramienta resultara más engorrosa que WhatsApp o el papel, no se usaría. Por eso la simplicidad de la interfaz se tomó como requerimiento no funcional con importancia totalmente prioritaria.

## **13.4 Factibilidad temporal** {#13.4-factibilidad-temporal}

El alcance se ajusta al tiempo disponible mediante la estrategia de incrementos explicada en el punto 10 (Incrementos o iteraciones definidas): se prioriza un producto mínimo funcional y luego se agregan las demás funcionalidades. Esto hace que el proyecto sea entregable dentro del calendario del curso aun si alguna función se alarga fuera del plazo establecido.

## **13.5 Factibilidad legal** {#13.5-factibilidad-legal}

El sistema maneja datos internos de la empresa y de personas (empleados y subcontratistas), por lo que se contempla el acceso restringido por usuario y contraseña y el control por roles. No se prevén dificultades legales para el alcance académico del proyecto, manteniendo buenas prácticas de protección de la información, sin pasar a una mayor escala.

## **13.6 Conclusión del estudio** {#13.6-conclusión-del-estudio}

Considerando las cinco partes de este estudio de factibilidad, el proyecto se considera totalmente factible. No se detectan obstáculos técnicos, económicos, funcionales, temporales ni legales que justifiquen no continuar con la construcción del software.

# **14\. Integrantes y roles** {#14.-integrantes-y-roles}

El equipo está formado por tres integrantes. Dado el tamaño del grupo, cada persona asume un rol principal para aumentar la productividad del mismo y participa además como desarrollador, de modo que las responsabilidades se reparten sin perder la visión general del proyecto. Esta organización funciona de manera correcta, con un enfoque ágil, donde el equipo es pequeño y multifuncional, achicando plazos que con un equipo de menor escala no se podrían realizar.

| Integrante | Rol principal | Responsabilidades |
| ----- | ----- | ----- |
| Juan Meny | Líder de proyecto, Scrum Master | Gestionar la planificación y el cronograma, liderar reuniones, verificar el cumplimiento de las iteraciones y elaborar la documentación. Participa en el desarrollo. |
| Alex Roth | Líder técnico, Responsable de SCM | Definir la arquitectura y los tipos de código utilizados, administrar el repositorio y la estrategia de ramas, integrar el trabajo del equipo. Participa en el desarrollo.  |
| Facundo Villalba | Responsable de SQA y Testing | Definir y aplicar el plan de calidad y de pruebas, mantener los casos de prueba y registrar errores. Participa en el desarrollo. |

Las tres personas comparten el rol de desarrollador. Las decisiones de mayor impacto en el software se realizan de manera conjunta.

# **15\. Descripción y selección de herramientas** {#15.-descripción-y-selección-de-herramientas}

La selección de herramientas se establece de la siguiente manera: que fueran adecuadas a las necesidades del proyecto, que el equipo tenga conocimiento en el funcionamiento de cada una, junto con su nivel actual de formación, y que sean gratuitas. La siguiente tabla resume las herramientas elegidas por categoría.

| Categoría | Herramienta | Justificación |
| ----- | ----- | ----- |
| Control de versiones | GitHub | Estándar de la industria; permite trabajo colaborativo, historial de cambios y respaldo del código en la nube. |
| Entorno de desarrollo | Visual Studio | Editor gratuito y con amplio soporte de extensiones para el lenguaje elegido. |
| Lenguaje y framework | C\# con ASP.NET Core (Razor Pages) | Tecnología web madura, vista en la carrera, adecuada para una aplicación de gestión. |
| Base de datos | MySQL | Garantiza integridad referencial, requerida por el sistema (sin registros huérfanos). |
| Gestión del proyecto | GitHub (Projects) | Visualiza el avance de las tareas. |
| Pruebas | Framework de pruebas unitarias | Permite verificar los servicios del sistema y automatizar pruebas de la lógica de negocio.  |
| Modelado y documentación | draw.io y Google Docs | Para diagramas (entidad-relación, casos de uso) y la redacción de la documentación. |
| Comunicación	 | WhatsApp, Discord y Zoom Meetings | Coordinación rápida del equipo y reuniones de revisión con el cliente.  |

El stack tecnológico utilizado podrá ajustarse durante el desarrollo según lo que el equipo maneje con mayor facilidad, manteniendo siempre el esquema de aplicación web con base de datos relacional.

# **16\. Plan de aseguramiento de la calidad (SQA)** {#16.-plan-de-aseguramiento-de-la-calidad-(sqa)}

El aseguramiento de la calidad del software (SQA) es el conjunto de actividades sistemáticas que se realizan a lo largo del proceso para garantizar que el producto cumpla con los requisitos y con los estándares definidos. No se trata solo de probar al final, sino de prevenir defectos durante todo el desarrollo.

## **16.1 Objetivos de calidad** {#16.1-objetivos-de-calidad}

Los atributos de calidad que se priorizan se establecen mediante los requerimientos no funcionales: seguridad (acceso controlado), usabilidad (interfaz simple), disponibilidad (acceso web) e integridad de los datos. El plan de SQA busca que cada iteración entregada cumpla estos atributos además de la funcionalidad esperada.

## **16.2 Estándares y convenciones** {#16.2-estándares-y-convenciones}

    • Establecemos convenciones de codificación; estas componen nombres descriptivos, consistencia en el idioma del código, comentarios en la lógica no evidente, etc.

    • Se cumple con el estándar de documentación, ya que cada documento sigue las normas de presentación de la institución.

    • Cumplimos además con una convención de commits y de ramas, definida en el plan de SCM (punto 8).

## **16.3 Revisiones** {#16.3-revisiones}

Se aplican revisiones, lo que significa que ningún cambio se integra a la rama principal sin que los demás integrantes lo revisen mediante una solicitud de incorporación (pull request). Además, al cierre de cada iteración se realiza una revisión en conjunto del producto y de la documentación. Las revisiones son, según Sommerville y Pressman, una de las técnicas más efectivas y económicas para detectar errores de manera preventiva.

## **16.4 Métricas** {#16.4-métricas}

Para un proyecto de este tamaño se utilizan métricas simples y útiles, como la cantidad de requerimientos cubiertos por iteración, la cantidad de defectos detectados y resueltos por iteración, y el porcentaje de casos de prueba que pasan. Estas métricas se revisan en las reuniones que dan cierre a la iteración.

## **16.5 Gestión de defectos** {#16.5-gestión-de-defectos}

Los defectos detectados se registran en el tablero del proyecto indicando su descripción, gravedad y estado (abierto, en proceso, resuelto). El responsable del SQA da la señal para su resolución antes de cerrar cada iteración.

# **17\. Plan de testing** {#17.-plan-de-testing}

El plan de pruebas define cómo se verificará que el sistema funciona correctamente. Sommerville distingue tres etapas: las pruebas de desarrollo (que hace el propio equipo), las pruebas de versión (sobre una versión completa) y las pruebas de usuario o aceptación (con el cliente).

## **17.1 Niveles de prueba** {#17.1-niveles-de-prueba}

    • Pruebas unitarias: verifican funciones o componentes individuales de la lógica de negocio de forma aislada.

    • Pruebas de integración: comprueban que los módulos funcionen correctamente al combinarse (por ejemplo, que el alta de un gasto se asocie bien a su obra).

    • Pruebas de sistema: validan flujos completos sobre el sistema integrado (registrar una obra, asignarle personal y materiales, y consultarla en el panel).

    • Pruebas de aceptación: las realiza el cliente, en este caso Alejandro, sobre escenarios reales para confirmar que el sistema resuelve su problema.

## **17.2 Tipos de prueba** {#17.2-tipos-de-prueba}

Además de las pruebas funcionales, se conocen pruebas de usabilidad (que el usuario complete tareas sin dificultad), pruebas de seguridad básicas (que un rol no acceda a acciones que no le corresponden) y pruebas de integridad de datos (que no queden registros sueltos al eliminar).

## **17.3 Estrategia por incremento** {#17.3-estrategia-por-incremento}

En base a la metodología ágil, las pruebas se realizan dentro de cada incremento y no solo al final. Cada módulo se prueba a medida que se construye y, antes de entregar una iteración, se realiza una prueba de regresión informal para confirmar que lo anterior sigue funcionando.

## 

## **17.4 Casos de prueba (ejemplos)** {#17.4-casos-de-prueba-(ejemplos)}

| Descripción | Entrada | Resultado esperado |
| ----- | ----- | ----- |
| Inicio de sesión con credenciales válidas | Usuario y contraseña correctos | El sistema permite el acceso y muestra el panel principal. |
| Inicio de sesión con credenciales inválidas | Contraseña incorrecta	 | El sistema rechaza el acceso y muestra un mensaje de error. |
| Alta de una nueva obra | Datos completos de la obra | La obra se registra y aparece en el listado y en el panel. |
| Registrar un gasto en una obra | Monto y categoría válidos | El gasto queda asociado a la obra y se refleja en el total. |
| Acceso restringido por rol | Usuario sin permiso de configuración | El sistema impide la acción y avisa que no está autorizada.  |

## **17.5 Criterios de aceptación** {#17.5-criterios-de-aceptación}

Una iteración se considera aceptada cuando todos sus casos de prueba críticos pasan, no quedan defectos de gravedad alta sin solucionar y el cliente valida la funcionalidad entregada en una reunión de revisión.

# **18\. Plan de gestión de la configuración (SCM)** {#18.-plan-de-gestión-de-la-configuración-(scm)}

La gestión de la configuración del software (SCM) administra los cambios sobre los productos del proyecto a lo largo del tiempo. El autor Pressman la describe como el control de la evolución de los mecanismos: saber qué hay, qué versión es la actual y cómo se incorporan los siguientes cambios sin perder trabajo ni generar conflictos con la versión más actual del proyecto.

## **18.1 Ítems de configuración** {#18.1-ítems-de-configuración}

Se identifican como ítems de configuración el código fuente, los scripts de la base de datos, la documentación del proyecto y los diagramas de modelado utilizados en toda la trayectoria.

## **18.2 Control de versiones y ramas** {#18.2-control-de-versiones-y-ramas}

El control de versiones se realiza con GitHub (Git). Se adopta una estrategia de ramas simplificada:

    • Rama principal (main): contiene siempre una versión estable y entregable.

    • Rama de desarrollo (develop): integra el trabajo en curso de la iteración.

    • Ramas por funcionalidad (feature): cada tarea se desarrolla en su propia rama y se incorpora a develop mediante pull request revisado, para luego ser integrada en la siguiente versión del software.

## **18.3 Gestión de cambios** {#18.3-gestión-de-cambios}

Los cambios de requerimientos propuestos por el cliente se registran y se evalúan en equipo por su impacto en el alcance y el cronograma antes de aceptarlos, y se incorporan al incremento correspondiente. Así se evita el descontrol del alcance.

## **18.4 Líneas base** {#18.4-líneas-base}

Al cierre de cada incremento se establece una línea base, o versión congelada, totalmente probada, la cual se marca con una etiqueta en el repositorio (por ejemplo, v1.0 para la siguiente iteración).

## **18.5 Respaldos** {#18.5-respaldos}

El alojamiento del repositorio en la nube actúa como respaldo del código. La base de datos del ambiente de prueba se respalda periódicamente mediante exportaciones locales.

# **19\. Plan de capacitación** {#19.-plan-de-capacitación}

La capacitación busca que el cliente pueda usar el sistema con total libertad. Es una etapa clave de la transición: un buen software mal explicado se queda en segundo plano o se abandona por completo.

## **19.1 Destinatarios** {#19.1-destinatarios}

El destinatario principal es Alejandro Pages, administrador y usuario central del sistema. Si en el futuro se incorporan otros usuarios con roles definidos, la capacitación se extenderá a ellos según sus permisos.

## **19.2 Modalidad y materiales** {#19.2-modalidad-y-materiales}

    • Sesiones prácticas guiadas sobre el sistema, presenciales o por videollamada, organizadas por módulo.

    • Manual de usuario breve, con pantallas y pasos para las tareas más frecuentes.

    • Videos cortos estilo tutorial de los flujos principales, como material de consulta posterior a dichas capacitaciones.

## **19.3 Contenidos** {#19.3-contenidos}

La capacitación cubre, en el siguiente orden: ingreso al sistema y gestión de la cuenta; registro y seguimiento de obras y uso del panel; asignación de personal; gestión de materiales y compras; registro de gastos e ingresos y lectura de reportes; y administración de usuarios y permisos.

## **19.4 Cronograma de capacitación** {#19.4-cronograma-de-capacitación}

La capacitación se realiza de forma incremental, es decir, al cierre de cada iteración se entrena al usuario en el módulo recién entregado, de modo que aprende sobre funcionalidad ya disponible. Al finalizar el proyecto se realiza una sesión de cierre que integra todos los módulos funcionales del sistema y se entrega el material de apoyo completo.

# **20\. Incrementos o iteraciones definidas** {#20.-incrementos-o-iteraciones-definidas}

Siguiendo la metodología ágil establecida, el sistema se construye de forma incremental: cada incremento entrega una funcionalidad probada y utilizable, priorizando primero un producto mínimo estable y agregando módulos en función del valor para el cliente. Las iteraciones se ordenaron según prioridad y dependencias entre módulos.

| Incremento | Objetivo / módulo | Requerimientos cubiertos | Entregable |
| ----- | ----- | ----- | ----- |
| Incremento 1 (MVP) | Autenticación, gestión de usuarios/roles, ABM de obras y panel básico.	 | RF1,RF5, RF6(parcial) | Versión funcional con acceso seguro y registro de obras. |
| Incremento 2 | Gestión de personal: ABM y asignación a obras. | RF3 | Módulo de personal integrado al sistema. |
| Incremento 3 | Gestión de materiales: requeridos, comprados y costos. | RF4 | Módulo de materiales y control de compras. |
| Incremento 4 | Gestión financiera: ingresos/egresos, rentabilidad y panel completo. | RF2, RF5 (completo) | Reportes financieros y panel general consolidado. |

Esta priorización permite que el cliente valide cuanto antes el núcleo general del sistema (acceso seguro y gestión de obras), que es la base sobre la que se apoyan los módulos siguientes. Los requerimientos que se muestran corresponden a los definidos en el Hito 1\.

# **21\. Cronograma de trabajo y criticidad** {#21.-cronograma-de-trabajo-y-criticidad}

## **21.1 Cronograma** {#21.1-cronograma}

El siguiente cronograma organiza el trabajo por etapas e incrementos estimados a lo largo del período del proyecto. Las fechas son estimadas, ya que varias formaciones se dan con el correr del semestre académico, y además se revisan en cada iteración, tal como recomienda la planificación ágil.

| Etapa | Actividades principales | Período (estimado) | Criticidad |
| :---- | :---- | :---- | :---- |
| Planificación y diseño	 | Plan de proyecto, modelo de datos, diseño de arquitectura y de pantallas. | Marzo – Abril 2026 | Alta |
| Incremento 1 | Autenticación, usuarios/roles, ABM de obras, panel básico y pruebas. | Abril – Mayo 2026 | Alta |
| Incremento 2 | Módulo de personal, integración y pruebas. | Mayo 2026 | Media |
| Incremento 3 | Módulo de materiales, integración y pruebas. | Mayo – Junio 2026 | Media |
| Incremento 4 | Módulo financiero, panel completo y pruebas. | Junio 2026 | Alta |
| Cierre | Pruebas de aceptación, capacitación, documentación final y entrega. | Junio – Julio 2026 | Alta |

			

		

			

			

			

			

## **21.2 Análisis de criticidad** {#21.2-análisis-de-criticidad}

La criticidad indica el impacto que tiene el atraso de una etapa sobre el resto del proyecto, una idea cercana a la del «camino crítico» en la gestión de proyectos. Las etapas de criticidad alta son aquellas de las que dependen las demás o que condicionan la entrega final:

    • La planificación y el diseño son críticos porque definen la base del sistema; un error aquí se propaga a todos los incrementos.

    • El Incremento 1 es crítico porque incluye la autenticación y el ABM de obras, sobre los que se construyen los módulos posteriores: ningún incremento siguiente puede avanzar sin él.

    • El Incremento 4 y el cierre son críticos por su cercanía a la fecha de entrega; cualquier atraso aquí afecta directamente el cumplimiento del plazo.

    • Los incrementos 2 y 3 tienen criticidad media: son importantes, pero su eventual atraso puede absorberse reordenando prioridades sin comprometer el núcleo del sistema.

Para mitigar los riesgos sobre las etapas críticas se prioriza terminar primero el MVP, se mantienen reuniones de revisión frecuentes con el cliente y se prueba dentro de cada incremento para no acumular defectos hacia el final.

# **22\. Bibliografía** {#22.-bibliografía}

PRESSMAN, Roger S. 2010\. *Ingeniería del software: un enfoque práctico.* 7ma. ed. México: McGraw-Hill.

SOMMERVILLE, Ian. 2011\. *Ingeniería de software.* 9na. ed. México: Pearson Educación.

# **23\.  Anexos**

## **Anexo A) Transcripción de la entrevista**

Transcripción del testimonio del cliente, Alejandro Pages, donde detalla los principales problemas operativos que motivan el desarrollo del sistema:

*“El principal problema que tenemos es el desorden, hoy manejamos la información por muchos lados distintos, desde WhatsApp hasta planillas de Excel, cuadernos, o algunos documentos sueltos. Entonces cuando necesitamos buscar algo muchas veces perdemos tiempo o directamente no encontramos nada de esa información. Eso nos complica bastante el día a día, por ejemplo, cuando tenemos varias obras al mismo tiempo se nos hace difícil hacer un buen seguimiento, a veces no tenemos claro en qué etapa está cada obra, qué materiales faltan, o cuánto se ha gastado realmente.*

*Otro problema importante es el tema de los números, registramos gastos y pagos, pero no de forma ordenada, entonces, después nos cuesta saber si una obra nos dejó ganancias o pérdidas, y eso para nosotros es clave. También tenemos dificultades con el manejo del personal, no siempre tenemos claro quién está trabajando en qué obra, desde cuándo, o qué tarea está realizando. Muchas veces, eso se maneja por mensajes o llamadas y no queda registro alguno.*

*Con los materiales pasa algo parecido, sabemos más o menos qué se necesita, pero no tenemos un control claro de qué se compró, qué falta comprar, o cuánto costó cada cosa. Esto a veces genera compras duplicadas o gastos innecesarios.*

*Además, no tenemos una vista general de la empresa, nos cuesta responder preguntas básicas como: ‘¿Cuántas horas tenemos activas?’, ‘¿En qué estado está cada una de las obras?’ o ‘¿Cómo viene el avance general?’. El seguimiento de las obras es bastante informal, no llevamos un registro claro del avance, ni porcentajes, ni historial, entonces cuando un cliente pregunta por el estado de su obra, no siempre podemos responder rápido o con información precisa.*

*Otro punto, es que la comunicación interna no es la mejor, porque dependemos mucho de WhatsApp o de llamadas, y eso hace que la información no quede registrada y se pierda fácilmente. Por último también nos importa el tema de la seguridad de la información, hoy cualquiera puede acceder a ciertos datos o modificarlos y no tenemos un control claro de quién puede hacer qué.”*