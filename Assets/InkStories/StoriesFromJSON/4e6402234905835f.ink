VAR StoryTittle = ""
VAR StoryQuestion = "What should we do?"
VAR StoryCategory = "Family"
VAR TextForLog = ""

VAR Character0OccupationSc = "Retirement"
VAR Character0MinAgeSc = 60
VAR NPC0RelationshipSc = "Partner"
VAR NPC0MinAgeSc = 60
VAR NPC1RelativesSc = "Kid"

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HealthCh = 0
VAR Character0WealthCh = 0

Our kid %FullName:NPC:2% loses %Pron:2:3% job.
What should we do?
* [Offer that %FullName:NPC:2% stay with us to save money.]
    -> res1
* [Lend %FullName:NPC:2% some money.]
    -> res2
* [Tell %FullName:NPC:1% to call contacts from %Pron:1:3% old job.]
    -> res3

=== res1 === 
It's actually a joy having %FullName:NPC:2% back around the house and we all grow closer together.
~TextForLog = "%FullName:NPC:1% thanks me for making this decision because we both got to reconnect with %FullName:NPC:2% and we allowed %Pron:2:2% to save some money while looking for another job. In the process we even learned quite a bit about %FullName:NPC:1%'s field of work."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
We lend %FullName:NPC:2% $2,000 out of our savings so that %Pron:2:1% can survive a few months while looking for work.
~TextForLog = "It did feel good to lend the money to %FullName:NPC:2% and me and %FullName:NPC:1% had the extra money saved. This should go a long way in letting %FullName:NPC:2% get back on %Pron:2:3% feet. However, just seeing %Pron:2:2% like this stresses me out and I have begun overeating junk food and just have a ton of bad eating habits now."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-2000%"
~NPC1HappinessCh = "%ValueRef:1:+%"
~NPC1RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% calls around but is annoyed that I asked %Pron:1:2% to do this.
~TextForLog = "I thought %FullName:NPC:1% would be happy to help out %FullName:NPC:2% but I guess %Pron:1:1% didn't want to be asking former coworkers for favors. %Pron:1:1% is annoyed with me but %Pron:1:1% does manage to get %FullName:NPC:2% a job to which %Pron:2:1% is so thankful to us."
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
