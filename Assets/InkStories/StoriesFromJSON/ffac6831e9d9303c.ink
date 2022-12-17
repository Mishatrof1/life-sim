VAR StoryTittle = ""
VAR StoryQuestion = "%Pron:1:1% asks when I think we should celebrate it. Which day should I pick?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 60
VAR NPC0RelationshipSc = "Partner"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 60

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0WealthCh = 0

Mine and %FullName:NPC:1%'s anniversary is this Friday.
%Pron:1:1% asks when I think we should celebrate it. Which day should I pick?
* [Friday]
    -> res1
* [Saturday]
    -> res2
* [Sunday]
    -> res3

=== res1 === 
It's nice to celebrate our anniversary on the actual day and we have a nice time but we're both so beat from having just worked all day.
~TextForLog = "It's nice to celebrate an anniversary on the actual day of the anniversary, but I think we would've benefitted from celebrating on a day we didn't also work. It was still a nice time, but we ended the night early. On the plus side, we were so tired that we went to sleep early and got a great night's sleep!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We wait until Saturday when we have no work and are able to have an excellent anniversary celebration.
~TextForLog = "I'm glad we waited for Saturday since %FullName:NPC:1% and I both worked Friday, we were pretty tired Friday night after work. But Saturday, we had the whole day off and were able to really celebrate the anniversary right. We had a nice, long celebration and had an excellent night together."
~Character0HappinessCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
We wait until Sunday but then I end up needing to do work and we have to cancel.
~TextForLog = "I find out the work I did Friday wasn't completely saved and so Sunday I have to go into the office to redo some of my work. Not only is that horrible but %FullName:NPC:1% is obviously so mad at me for having to cancel and now I am just miserable. But I do get a bit of overtime pay... the one tiny silver lining in this dark, overcast cloud."
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0WealthCh = "%100%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END
