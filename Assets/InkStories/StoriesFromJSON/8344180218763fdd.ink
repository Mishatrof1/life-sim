VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 4
VAR Character0MaxAgeSc = 5
VAR NPC0OccupationSc = "HigherInPosition"
VAR NPC0GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0WisdomCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

My teacher, %FullName:NPC:1%, keeps giving me really boring books to read at home. But %Pron:1:1% is lovely.
What should I do?
* [Just read the books, and save %FullName:NPC:1%'s feelings. ]
    -> res1
* [Tell %FullName:NPC:1%. I need to put my reading skills first!]
    -> res2
* [Switch the books myself, in secret? Save %FullName:NPC:1%'s feelings?]
    -> res3

=== res1 === 
I am really bored of those books now, but at least %FullName:NPC:1% doesn't know that I am. Sometimes you have to take the hit to save someone else's feelings. She's a great teacher!
~TextForLog = "I had to read some boring books, but at least I didn't upset %FullName:NPC:1%. She's such a great teacher!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I shouldn't have been worried! %FullName:NPC:1% was happy to help - I guess it's not that much trouble, and she seemed really happy that I have an opinion. I now have great books to read! 
~TextForLog = "Who knew? Teachers actually LIKE helping their pupils! %FullName:NPC:1% was more than happy to switch my reading books, and now I'm reading like crazy again! "
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I switched the books myself! But %FullName:NPC:1% found out and told me that it messed up her system and made work. I have switched to better books, but %FullName:NPC:1% seemed put out. 
~TextForLog = "Oh dear, I messed up a bit. %FullName:NPC:1% is still the best teacher I've ever had, which is why I'm sad I made life difficult for her messing about with the reading books. At least I have better books now!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
