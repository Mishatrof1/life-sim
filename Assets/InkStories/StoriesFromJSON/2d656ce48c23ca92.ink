VAR StoryTittle = ""
VAR StoryQuestion = "Which gift should I choose?"
VAR StoryCategory = "Gold"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool:College"
VAR Character0MinAgeSc = 11
VAR Character0MaxAgeSc = 22

VAR Character0HealthCh = 0
VAR Character0StrengthCh = 0
VAR Character0AthleticismCh = 0
VAR Character0HappinessCh = 0

I'm at a White Elephant Christmas party and am about to choose a gift.
Which gift should I choose?
* [The present in blue gift wrapping paper.]
    -> res1
* [The present in yellow gift wrapping paper.]
    -> res2

=== res1 === 
I open it up and it is a set of resistance fitness bands.
~TextForLog = "These resistance bands are great! I started using them as soon as I got home and they really help me to get in better shape pretty quickly."
~Character0HealthCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
It's an assortment of different flavored potato chips.
~TextForLog = "I actually love this! It has so many great flavors of potato chips! I start eating some of them as soon as I get home and keep eating them all through the week. It definitely makes me happy but it also makes me feel... slow... and out of shape."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
* [Ok]
-> END
