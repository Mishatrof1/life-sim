VAR StoryTittle = ""
VAR StoryQuestion = "What should we do?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 50
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0
VAR NPC0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0

Me and %FullName:NPC:1% are getting ready to golf when the employees of the place tell us there are no golf carts right now.
What should we do?
* [Golf anyway and just walk to each hole.]
    -> res1
* [Wait for golf carts to become available.]
    -> res2
* [Offer to pay an employee $50 each for a golf cart.]
    -> res3

=== res1 === 
This isn't so bad and in fact, we get some good exercise in walking from hole to hole. Plus, we get some sun.
~TextForLog = "%FullName:NPC:1% and I just walk from hole to hole. We wanted to get to golfing right away and we don't mind walking. In fact, we get some sun and a bit of exercise in and everything turns out alright. I feel like the sun tan on my skin has even gotten me looking a bit more appealing too."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0AppearanceCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We sit on a bench and wait a while until a golf cart is available to us. Finally one is available but sitting in one spot for so long we both get sunburnt.
~TextForLog = "We're actually really happy to be able to use the golf cart because it's so much fun to drive. However, once we're done golfing %FullName:NPC:1% and I realize we got really bad sun burn. Really bad. It's painful. We look like lobsters in golf pants."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
We offer the employee money and he gets us a golf cart. Then, we get to golfing right away.
~TextForLog = "Turns out if you flash some money golf carts just magically appear out of nowhere. I guess they keep some saved on the side. %FullName:NPC:1% is so glad I thought of us bribing the employee, we got to golfing right away and with a cart! It did cost us some money and maybe we could've used the exercise, but oh well, the carts are fun!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%%"
~NPC0RelationshipCh = "%%"
* [Ok]
-> END
