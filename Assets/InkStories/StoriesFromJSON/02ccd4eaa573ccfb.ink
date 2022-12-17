VAR StoryTittle = ""
VAR StoryQuestion = "All of our friends laugh and make fun of %Pron:1:2%. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"
VAR NPC0MinAgeSc = 8
VAR NPC0MaxAgeSc = 17

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC0SympathyCh = 0
VAR NPC0HappinessCh = 0

I'm going to be sleeping over %FullName:NPC:1%'s house but %Pron:1:1% tells me that %Pron:1:1% has a ghost in %Pron:1:3% house.
All of our friends laugh and make fun of %Pron:1:2%. What should I do?
* [Tell %FullName:NPC:1% it's probably just %Pron:1:3% imagination.]
    -> res1
* [Tell %FullName:NPC:1% we will get proof of the ghost.]
    -> res2

=== res1 === 
I go to %FullName:NPC:1%'s house and we see the ghost and I tell our friends and they don't believe me!
~TextForLog = "%FullName:NPC:1% was right! %Pron:1:1% does have a ghost in %Pron:1:3% house! And we saw the thing so I make sure to tell our friends the next time I see them so they don't think %FullName:NPC:1% is crazy but now they just think we are both crazy and call us little babies for being so scared. Real mature of them!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
At first everyone laughs at me too but when we actually get video proof they all apologize and are in awe of what we show them.
~TextForLog = "I believed %FullName:NPC:1% and decided we should get proof to show everyone. They thought I was crazy at first but %FullName:NPC:1% and I saw the ghost at %Pron:1:3% house and we were ready. We got a video of it and showed everyone. They all apologized to us... and now everyone wants to talk to us and see the video of the ghost."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
