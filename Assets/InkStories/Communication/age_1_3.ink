=== age_1_3
 ~ temp dice_roll = RANDOM(1, 6) 
 {dice_roll > 3: 
  * [Корчить умильные рожицы+10]
      ~Relationship += 10
      -> Result 
  * [Схватить за палец +3]
      ~Relationship += 3
      -> Result
  * [Измазаться своими экскрементами-10]
    ~Relationship -= 10
      -> Result 
   - else:
   * [Пукнуть и засмеяться +5]
    ~Relationship += 5
      -> Result 
   * [Привлечь к себе внимание криком]
    ~Relationship -= 5
      -> Result 
 } 
 
 -> Result 