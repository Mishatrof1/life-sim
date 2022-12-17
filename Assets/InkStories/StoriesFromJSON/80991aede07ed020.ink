VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 15
VAR Character0MaxAgeSc = 30
VAR NPC0RelationshipSc = "Crush"
VAR NPC0MinAgeSc = 15
VAR NPC0MaxAgeSc = 30

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC0HappinessCh = 0
VAR Character0IntelligenceCh = 0

I'm at the clothing store where %FullName:NPC:1% works and I want to ask %Pron:1:2% out.
What should I do?
* [Buy clothes first then ask %FullName:NPC:1% out at register.]
    -> res1
* [Ask %FullName:NPC:1% out first, then buy clothes after.]
    -> res2
* [Buy clothes and hand %FullName:NPC:1% my number on a piece of paper.]
    -> res3

=== res1 === 
When I'm trying to ask %FullName:NPC:1% out, there is a long line and I am holding it up and %Pron:1:1% turns me down.
~TextForLog = "I got the feeling that %FullName:NPC:1% might've just turned me down because it was an awkward situation and I was holding up the line and so many people were around. Maybe I should've asked %Pron:1:2% out when there was less people around. Either way, I am bummed out because %Pron:1:1% turned me down."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-40%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I ask %FullName:NPC:1% out and no one is around so I don't feel as pressured. And %Pron:1:1% says yes!
~TextForLog = "Luckily, when I went to ask %FullName:NPC:1% out, no one was around, so it made asking %Pron:1:2% out easier. %Pron:1:1% said yes and I'm so happy. And then I came back through the line with my clothes and %Pron:1:1% actually gave me a discount on my clothes too!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-25%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
As I bought my clothes there was a huge line so I think this was the right choice. %FullName:NPC:1% said %Pron:1:1% would call me too.
~TextForLog = "This was some quick thinking. I think I saved both of us some embarrassment because had I asked %FullName:NPC:1% out when all those people were around I think we both would've been blushing. Instead, I just slid %Pron:1:2% my number and %Pron:1:1% said %Pron:1:1% would call me. Alright! I think I got a date coming up soon!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-40%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
