VAR StoryTittle = ""
VAR StoryQuestion = "I've already had two coffees today. What should I say?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "Colleague"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22
VAR NPC1OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HealthCh = 0

%FullName:NPC:1% is going to get coffee and asks if I want one too.
I've already had two coffees today. What should I say?
* ["No."]
    -> res1
* ["Yes."]
    -> res2
* ["What about a lemonade?"]
    -> res3

=== res1 === 
%FullName:NPC:1% is a little upset and thinks I'm not interested in %Pron:1:2%
~TextForLog = "That was stupid of me! I should've just said yes. %FullName:NPC:1% thinks I'm not interested in %Pron:1:2% now and I actually am. I was just not really wanting another coffee after having two... maybe I should've asked for a lemonade instead? Well, at least I was able to get a lot of work done... since %FullName:NPC:1% wasn't talking to me much after that."
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% is so nice to bring me a coffee, but now I'm too hyper and can't focus at work.
~TextForLog = "I thank %FullName:NPC:1% for being so nice and we work together the rest of our shift and have a great time. We even schedule a date later! However, I'm so hyper that I can't focus on my work and our boss %FullName:NPC:2% is getting angry with me."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% goes out of %Pron:1:3% way to go to a place that has lemonade!
~TextForLog = "%FullName:NPC:1% is so sweet, driving somewhere else to get me a lemonade. And it's this super healthy and refreshing lemonade. Delicious! I can't believe it! We end up making a date later on too. "
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
