VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Pink"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 30
VAR Character0MaxAgeSc = 45
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 30
VAR NPC0MaxAgeSc = 45
VAR NPC1RelationshipSc = "Friend"
VAR NPC1GenderSc = "Opposite"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0

I'm at a party and approach %FullName:NPC:1% and slap %Pron:1:2% on the butt, but it turns out to be %FullName:NPC:2%.
What do I do?
* [Say it was a mistake, you thought %Pron:2:1% was %FullName:NPC:1%.]
    -> res1
* [Just pretend like everything is normal.]
    -> res2

=== res1 === 
%FullName:NPC:2% doesn't mind and is forgiving but %FullName:NPC:1% is mad that I confused the two.
~TextForLog = "%FullName:NPC:2% doesn't mind and even thinks it's funny. However, %FullName:NPC:1% is really mad at me for confusing the two. But they're wearing almost exactly the same outfit and have similar body types! That argument is not helping me though!"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
%FulName:NPC:2% doesn't seem to mind and is even laughing and %FullName:NPC:1% thinks it's funny too.
~TextForLog = "Wow, I just pretended like I meant it and everyone is totally fine with it. They even all think it was funny of me. If only they knew it was a complete mistake... but I'll never tell anyone!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
