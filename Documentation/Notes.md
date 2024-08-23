###### úvod
# Jak verzovat WebApi aplikaci
Tato prezentace je zaměřena na to jak můžeme verzovat naši `WebApi` aplikaci.
Cílem je ukázat různé druhy přístupů a jaké komplikace nebo výhody sebou nese každá technika.

info: kód jsem záměrně volil tak, aby byl sobě mezi jednotlivými technikami co nejpodobnější. Takže jsem v něm použil 'pouze' nezbytné prvky.
Motivací tohoto setkání je si zvědomit abstrakci toho, co který přístup obnáší. 

Obsah:
1. [Git verzování](#git)
2. [Bez Versioning](#bez-versioning)
3. [Basic Versioning](#basic-versioning)
4. [Conventional versioning](#conventional-versioning)
5. [API Version Selector](#api-version-selector) _.Net atributy_

<br/>
<hr style="border: none; border-top: 3px solid darkgrey;" />
<br/>

###### _Kapitola 1_
# Git
## GitVersion
 - verzovací nástroj pro definici **Major - Minor - Patch**
   - doplnit vysvětlení kdy použít změnu Major nebo Minor nebo Patch
 - příklad z DockerHub image: https://hub.docker.com/_/nginx  -> [prtscr](TagsInDockerImageNginx.jpg)

## Gitflow-workflow versus TrunkBase
Do Gitflow-workflow nemohu napěchovat verzování. existuje pouze jedna verze produktu, která je distribuována.

pokud potřebuji produkt verzovat, mám v gitu k dispozici `TrunkBase`. 
Ten umožňuje vyvíjet produkt, po nasazení ho optimalizovat bez vlivu na hlavní proud vývoje

<br/>
<hr style="border: none; border-top: 3px solid darkgrey;" />
<br/>

###### _Kapitola 2_
# Bez Versioning
Controllery bez verzování - projekt `Basic_NoVersioning`

<br/>
<hr style="border: none; border-top: 3px solid darkgrey;" />
<br/>

###### _Kapitola 3_
# Basic Versioning
Controllery mají v názvu číslo verze - `Major-Minor-Patch`

Vhodné pro případy, kdy nevzniká mnoho verzovaných endpointů.

### Nový Endpoint je označení, v které verzi endpoint vznikl.
není to informace o verzi endpointu (nebo nemusí).

## Testování
end-to-end unit testy

Nutné verzovat i všechny třídy které verzovaný endpoint využívá.
Vytvoření jejich verze: copie třídy, přejmenování se zachování původního jména a přidání postfixu čísla verze.
příklad: `Company`-> `Company20240200`

<br/>
<hr style="border: none; border-top: 3px solid darkgrey;" />
<br/>

###### _Kapitola 4_
# Conventional versioning

**Microsoft Doc:** 
https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-8.0#use-application-model-to-customize-attribute-routes

## Na co myslet při vytváření nové verze:
 Když chci, aby se projekty vkládali pěkně do složek jako ve windows musím:
  - ve file exploreru vytvořit nové složky (Rider ok)
  - V solution exploreru vytvořit `Solution folder` se absolutně stejným názvem (Rider ok)
  - jít zpět do file exploreru a nakopírovat projekty (Rider nok)
  - V solution exploreru:
    - vložit již existující projekt (vybrat nově nakopírované) - dá se jen jeden po druhém
    - Přejmenovat jej včetně `Rename root namespace` - přejmenuje to i ve file exploreru, v opačném případě se vytvoří kopie s novým názvem a projekt bude v dané složce dvakrát.
  - Adjust namespaces
  - změna swagger tagů - musí se použít, jinak swagger nevygeneruje soubor s dokumentací -> v prohlížei error.
  - POZOR - **musí se namapovat projekty se správnou verzí!**
    - při kopírování zůstává v `using`původní namespace a je velmi snadné ho znovu použít.

<br/>
<hr style="border: none; border-top: 3px solid darkgrey;" />
<br/>

###### _Kapitola 5_
# API Version Selector

## Verzování pomocí .NET attributes

Musím dekorovat endpoint verzí. Tato verze potom musí být uvedena v URL adrese.
<br/> Deklarace endpoint verzí může být realizováno např., těmito způsoby:

### Query parameter
Definici verze endpointu zadám jako parametr.
**_Controller atributy:_**
<br/> `[ApiVersion( 2.0 )]`
<br/> `[Route( "api/[controller]/[action]" )]`
<br/> HTTP request vypadá takto: `GET http://localhost:5038/api/Company/ReadCompanyInfo?api-version=2.0`


### URL path segment
Jeden segment v url je vyhrazen pro definici verze.

**_Controller atributy:_**
<br/> `[ApiVersion( 2.0 )]`
<br/> `[Route( "api/v{version:apiVersion}/[controller]/[action]" )]`
<br/> HTTP request vypadá takto: `GET http://localhost:5038/api/v3.0/Company/ReadCompanyInfo`


## Výhody
 - Každý endpoint má něměnný název skze všechny verze
 - V případě, že třídu kontraktu mám ve stejné struktuře, tak držím stejný název třídy přes všechny verze.

## Nevýhody
 - s každou novou verzí musím vytvořit kompletní duplikaci celé verze.
 - pokud budu chtít oddělit třídy kontraktů od od projektu s kontrolery, musím stanovit jak  se budou pojmenovávat a při vytvoření nové změny všechny jejich instance přepsat na správnou verzi.
   - podobně jako v projektu `Basic_Versioning`.

**Pozor:** pokud budu verzovat pouze změnované části kontrolerů, mohu vnést chaos do celého verzování.

dokumentace: ohláška autora: https://github.com/dotnet/aspnet-api-versioning/discussions/807

# Doporučení  - Best practise