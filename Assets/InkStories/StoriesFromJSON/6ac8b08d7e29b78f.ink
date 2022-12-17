VAR StoryTittle = ""
VAR StoryQuestion = "Where should we choose to go?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 9
VAR Character0MaxAgeSc = 16
VAR NPC0RelativesSc = "Sibling"
VAR NPC0GenderSc = "Female"
VAR NPC1RelativesSc = "Parent"
VAR NPC1GenderSc = "Female"
VAR NPC2RelativesSc = "Parent"
VAR NPC2GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC2HappinessCh = 0
VAR NPC2RelationshipCh = 0
VAR Character0WealthCh = 0

%FullName:NPC:1% and I are going to go for a run but aren't sure where we should run.
Where should we choose to go?
* [Run through the trails in the woods.]
    -> res1
* [Run through our neighborhood.]
    -> res2
* [Run all the way to the school and back.]
    -> res3

=== res1 === 
%FullName:NPC:1% tells me to go ahead without her when she starts to get tired. I do so and lose her and she gets lost in the woods.
~TextForLog = "I get home and my parents ask me where %FullName:NPC:1% is and I don't know. We all have to go out and look for her and eventually find her. She was lost in the woods. I am in so much trouble now. Pretty sure everyone hates my guts now."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
~NPC1HappinessCh = "%ValueRef:1:-%"
~NPC1RelationshipCh = "%ValueRef:1:-%"
~NPC2HappinessCh = "%ValueRef:1:-%"
~NPC2RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% and I get a pretty good run in but the weirdest thing is that a cop car and another car speed by and a bag of money is thrown from the window filled with money.
~TextForLog = "Our run was cut short because as we're passing through the neighborhood, a cop car was chasing another car right past us and a bag of money flew out the window! We picked it up and counted it, $2,000! We brought it home and kept $500 each and gave $500 to each of our parents. I feel a shopping spree coming on!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0WealthCh = "%500%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC1HappinessCh = "%ValueRef:1:+%"
~NPC1RelationshipCh = "%ValueRef:1:+%"
~NPC2HappinessCh = "%ValueRef:1:+%"
~NPC2RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
This ends up being the perfect run. Me and %FullName:NPC:1% are tired by the end of it, but we make it. 
~TextForLog = "This was a great run, we're going to remember this route. It was perfect for us, just the right distance. I mean, I could've gone a little longer, but it was perfect for %FullName:NPC:1% so it works for me. I am feeling great now!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%%"
~NPC0RelationshipCh = "%%"
* [Ok]
-> END
