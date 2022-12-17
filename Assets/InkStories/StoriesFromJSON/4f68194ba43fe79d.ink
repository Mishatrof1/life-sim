VAR StoryTittle = ""
VAR StoryQuestion = "Where should we go to?"
VAR StoryCategory = "Friends:Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 21
VAR Character0MaxAgeSc = 30
VAR NPC0RelationshipSc = "SignificantOther"
VAR NPC0MinAgeSc = 21
VAR NPC0MaxAgeSc = 30
VAR NPC1RelationshipSc = "Friend"

VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR Character0HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HealthCh = 0
VAR NPC0SympathyCh = 0
VAR NPC1SympathyCh = 0

I'm with %FullName:NPC:1% and %FullName:NPC:2% and we're trying to pick a bar to go to.
Where should we go to?
* [Choose %FullName:NPC:1%'s favorite bar.]
    -> res1
* [Choose %FullName:NPC:2%'s favorite bar.]
    -> res2
* [Choose my favorite bar]
    -> res3
* [Choose a new bar]
    -> res4

=== res1 === 
%FullName:NPC:1% loves the choice, %FullName:NPC:2% is a little annoyed.
~TextForLog = "This place is pricey but it was worth it because %FullName:NPC:1% loves it there. %FullName:NPC:2% was a little annoyed I just picked %Pron:1:2% favorite bar, as if I was sucking up or something. But you can't always please everyone right?"
~Character0WealthCh = "%-40%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:2% loves the choice and %FullName:NPC:1% actually gets mad at me.
~TextForLog = "%FullName:NPC:1% tells me I always do this and choose stuff that %FullName:NPC:2% likes over %Pron:1:2%. I don't think that I do that, but whatever. It doesn't matter, we end up getting into an argument over it. So dumb. I don't know why %Pron:1:1% can't just enjoy %Pron:1:5%."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-25%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
Everyone loves this place, so I really picked right.
~TextForLog = "Don't mind saying so myself, I have the best taste. Not only is my favorite place the best, but everyone enjoys it. So, everyone can have a good time together. Not always the case when we go to other places. So, I'm just going to keep choosing my favorite bar as it is the crowd pleaser."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-30%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
Everyone has fun here but something is wrong with one of my drinks and I get sick.
~TextForLog = "Well, this seemed like a happy compromise until I tried some new drink on their menu and get seriously sick from it. And not like, I drank too much, kind of sick. They put something weird in that drink. I do not want to come back to this bar ever again. I don't know what they're putting in their drinks but it's not anything you're supposed to ingest."
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-20%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
~NPC1SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
