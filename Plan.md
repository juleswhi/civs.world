# Country Of Owls

What is Country of owls?

- A Civ like game right in the browser
- Real Time Campaigns over long periods of time
- Communication between players
- Each player controls a country

## Browser 

- ASP.NET
- MVC
- SQL
- RAZOR / REACT?
## Real Time Campaigns / Communication between players

- Messaging between players
- Live updating of player statistics
- Live Map of what areas are controlled by who

## Each player controls a country

### Needed functionality

- A Country Class
{
    Country ID 
    Player ID

    Religion   

    TrustScore

    Armies controlled by the country
    Country Statistics for all measures
}
- An Army Creation and management system

- A Banking system and management system
    - Single World Bank? = better investment rates

- Alliances
    - Formation of alliances
    - Sending resources between allies
    - Single pool of resources?

    Methods
    {
        Create Alliance
        Request to join an alliance
        invite a player to an alliance
        leave an alliance ( peaceful )
        leave an alliance ( hateful )
        dissolve alliance ( through vote )
        request resources from alliance members
    }

- Resources
    - "Pools" of resources?
    - Each country has an abundance of a singluar resource
    - No distinctive resource is better than another
    - Each resource can be used to upgrade something / do something 
    - Promotes hagglign between players
    - Each material has a selling price, if high sell, then not as useful in other industries
    - Selling Price ++, Used in Skill Tree ++
    - Resources are grouping into "Stacks", a stack is equivalent to 100 tons worth

    Methods
    {
        Randomly choose which country has which resource
        Choose Selling Price and Usefullness
    }

- Trading / Banking
    - Allows players to send resources and money to other players
    - players must trust other players for trades because it is easy to betray agreements due to no formal trading system

    Methods
    {
        Banking:
            Transfer Money
            View Balance
            Create a bank account
            Create a bank ( for nation )
            Withdraw Money

        Trading:
            Transfer Resources ( one way )
            Request Resources
    }


- Tech Tree
    - Allow players to progress through differenet pathways and profeciences through a skill tree
    - Each major industry / skill will have a skill tree that players can use money and other resources to upgrade
    - Forcing a player to gain moderate amounts of all resources to upgrade their skill tree promotes cooperation but also mind games between players
    - Requirements for a node e.g 20 Stacks of Hay 

    Methods
    {
        Create Skill Tree
        Generate Pathways
        Distrubute Resources Evenly 
    }


- Wars
    - Players can engage in wartime with any other country
    - Player's countries religious beliefs affecet ability to go to war; Pacifist nation, no war
    - Wartime will block all communications between countries?
    - Players can fight which winner will be determined by army size and slight randomness, or can stay at non-violence while being in a state of war

    Methods
    {
        DeclareWar
        Fight Enemy
        Vote to dissolve War
    }

- Companies
    - Players can invest in real world companies
    - Maybe use some sort of api to correlate investment in companies to the respective companies' stock price irl?
    - Companies can improve some aspects of life in a country and help with skill tree knowledge

- United Nations
    - A single group chat where all countries can propose new ideas and communicate
    - If every other member of the UN votes, then a member can be disbanded

    Methods
    {
        Talk to others memebers
    }


# TODO:

update all models to use in MongoDB

update databse when transferring funds etc





# ***MAP***

- C# Class => List of names, score etc taken from database
- Serialise C# Class => JSON
- JSON is used in webpage to display usernames and score


Move hash to a separate file for the love of god



# => ***Sessions*** 
  - When user logs in ask to rememeber them
  - store user id in session
  - if user id is null then redirect to login page


