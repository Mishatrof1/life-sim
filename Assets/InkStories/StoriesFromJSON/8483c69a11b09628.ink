VAR StoryTittle = ""
VAR StoryQuestion = "%FullName:NPC:1% is upstairs though. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 50
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 50

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0WisdomCh = 0
VAR NPC0SympathyCh = 0

It's late at night and I am about to head down to the basement and hear laughing and muttering down there.
%FullName:NPC:1% is upstairs though. What should I do?
* [Go down to the basement with a knife]
    -> res1
* [Go down with my phone and film]
    -> res2
* [Go down with %FullName:NPC:1%]
    -> res3

=== res1 === 
I see someone down there who charges me, attacks me and vanishes!
~TextForLog = "%FullName:NPC:1% comes down to check on me. I am injured and bleeding and tell %Pron:1:2% that there was a ghost down here. %Pron:1:1% doesn't believe me and is mad at me for blaming my clumsiness on ghosts that aren't real. But I know what I saw!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I am filming with my phone when I see someone who charges me, attacks me and vanishes.
~TextForLog = "%FullName:NPC:1% comes down to check on me and I show %Pron:1:2% the video. We both agree, we just witnessed an aggressive ghost in our basement that attacked me. %Pron:1:1% helps get me bandaged up and we are both so scared, we're not sure if we can even sleep tonight. The evidence on my phone... it's taught us to think very differently."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
We both go down, see someone down there who sees us, looks around and vanishes.
~TextForLog = "We cannot believe it even though we saw it with our own eyes. That was a ghost... or something. It had to be. We saw someone who just disappeared. But weirdly, after this incident, things seemed to just feel better and brighter around the house. The two of us had been feeling negative recently and now that's gone. What an interesting turn of events."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
