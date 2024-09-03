import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-trial',
  templateUrl: './trial.component.html',
  styleUrls: ['./trial.component.css']
})
export class TrialComponent implements OnInit {
Date1:any
Date2:any
Days:any
  constructor() { }

  ngOnInit(): void {
    this.CalculateDays();
  }
  CalculateDays()
  {
    const Date1Modified =new Date(this.Date1);
    const Date2Modified =new Date(this.Date2);

   const Time= Date2Modified.getTime()-Date1Modified.getTime();
   this.Days=Time/(1000*3600*24);
  }

}
