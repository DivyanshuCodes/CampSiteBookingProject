import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  Data!: any; p: any;
  Capacity = '';
  SearchCapacity='';
  SortbyParam='';
  SortDirection='asc';
  Page: any;
  constructor(private auth: AuthService) { }

  ngOnInit(): void {
    this.showCampData()
  }
  showCampData() {
    this.auth.viewCamp().subscribe((res: any) => {
      this.Data = res;
    })
  }
  BookNow(data:any)
  {
    this.auth.setData(data);
  }
  onCapacityFilter() {

    this.SearchCapacity = this.Capacity;
  }
  onCapacityFilterClear(){

    this.Capacity='';

    this.SearchCapacity='';
  }
  onSortDirection(){

    if(this.SortDirection==='desc'){

      this.SortDirection='asc';
    }
    else{
      this.SortDirection='desc';
    }
  }
}