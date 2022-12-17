VAR StoryTittle = ""
VAR StoryQuestion = "Do I ask Mom or Dad... or both?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid"
VAR Character0MinAgeSc = 3
VAR Character0MaxAgeSc = 5
VAR NPC0RelativesSc = "Parent"
VAR NPC0GenderSc = "Male"
VAR NPC1RelativesSc = "Parent"
VAR NPC1GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0WisdomCh = 0

I just saw the new Robotron Attack Blaster in the shop window, but I haven't got enough pocket money... I need an advance on next week's!
Do I ask Mom or Dad... or both?
* [Ask Mom. She's always a big softie if I say 'Pretty please."]
    -> res1
* [Ask Dad - I drew him a lovely picture this morning, so I think he'll say yes!]
    -> res2
* [Ask them both - they like to make decisions together!]
    -> res3
* [Borrow' the extra cash from Mom's purse. ]
    -> res4

=== res1 === 
I asked Mom for an advance on next week's pocket money, and she said yes! I bought the new Robotron Attack Blaster. But Dad was not happy: he likes to be consulted. They had a squabble!
~TextForLog = "I made my mom and dad have a fight... I asked my Mom for extra pocket money to get a new toy, and Mom and Dad ended up squabbling about it. Whoops!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-5%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
Dad gave me a really long talk about something called 'Finances', which was complicated. It made Mom laugh! And then he finally said yes, and I now have a Robotron Attack Blaster! 
~TextForLog = "Dad lent me an advance on next week's pocket money, and so I now have a Robotron Attack Blaster! Mom found Dad's boring talk about Finances really funny for some reason. "
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-5%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:1:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I asked Mom and Dad at the same time, and they simultaneously both gave opposite answers. Then they smiled and laughed. Finally, they agreed and let me get my Robotron Attack Blaster!
~TextForLog = "I asked both my parents for extra pocket money to buy the Robotron Attack Blaster. They loved both being asked, it turned out. Yay!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-5%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
I was so close, but Mom's handbag is really messy, and I couldn't find the money I needed. Instead, I got caught, got a telling off, and got last week's pocket money taken too. Crime doesn't pay. 
~TextForLog = "I got caught trying to 'borrow' some money from Mom's purse. I learned my lesson and I feel sad. The Robotron Attack Blaster will have to wait, but at least I've learnt that crime doesn't pay. "
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-5%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
~NPC1HappinessCh = "%ValueRef:1:-%"
~NPC1RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END
