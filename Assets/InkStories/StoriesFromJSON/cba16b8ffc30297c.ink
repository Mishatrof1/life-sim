VAR StoryTittle = ""
VAR StoryQuestion = "What drinks should we get?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 21
VAR Character0MaxAgeSc = 35
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"
VAR NPC0MinAgeSc = 21
VAR NPC0MaxAgeSc = 35

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR Character0HealthCh = 0
VAR NPC0RelationshipCh = 0

I'm out at a bar with %FullName:NPC:1% and we are trying to decide on drinks.
What drinks should we get?
* [The Flying Dutchman.]
    -> res1
* [The Sorcerer's Wand.]
    -> res2
* [The Pink Pig Lady]
    -> res3

=== res1 === 
This drink is extremely expensive but delicious and has quite the kick.
~TextForLog = "Me and %FullName:NPC:1% enjoy our Flying Dutchmans... Flying Dutchmen? Either way, they were really good. But REALLY expensive."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-15%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
These drinks aren't too badly priced but they are way too strong for us.
~TextForLog = "Me and %FullName:NPC:1% felt the full effect of The Sorcerer's Wands that we had... and then we had a really deep, meaningful conversation and really connected on another level. It would have been a great night had we not both gotten sick later on."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-10%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
These drinks were so cheap, but we hardly feel anything. They taste pretty good though.
~TextForLog = "These turn out to be healthy alcoholic drinks... which I had never heard of. They use all sorts of different ingredients that you don't normally see in drinks. But we don't feel too much from them. But we have a good time drinking these and having good conversation and hey, saving some money while we're at it!"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-5%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
