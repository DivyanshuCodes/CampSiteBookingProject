import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-manage-booking',
  templateUrl: './manage-booking.component.html',
  styleUrls: ['./manage-booking.component.css'],
  providers: [NgbRatingConfig]
})

export class ManageBookingComponent implements OnInit {
  @Input()rating!: number;

  @Input() itemId !: number;

  @Output() ratingClick: EventEmitter<any> = new EventEmitter<any>();
  inputName: string = '';
searchForm!:FormGroup
ratingForm!:FormGroup
editForm!:FormGroup
show:boolean=false;
data:any={}
currentRate = 0;
  constructor(private formBuilder:FormBuilder,private auth:AuthService,private http:HttpClient,config: NgbRatingConfig) { 
    config.max = 5;
  }

  ngOnInit(): void {
    this.inputName = this.itemId + '_rating';
    this.searchForm=this.formBuilder.group({referenceNo:['']})
    this.editForm = this.formBuilder.group({
      campId: ['', Validators.required], name: ['', Validators.required,], rate: ['', Validators.required],
      capacity: ['', Validators.required], description: ['', Validators.required], url: ['', Validators.required]
      ,status:['']
    })
    this.ratingForm=this.formBuilder.group({
      campId:[''],totalRating:[''],numberRating:[''],averageRating:['']
    })
  }
  search()
  {
    this.auth.findBooking(this.searchForm.value.referenceNo).
    subscribe(res=> {
      if(res!=null){
      this.data = res;
      console.log(this.data);
      this.show=true;
      }
      else{
        alert("Invalid reference number!")
      }
    })
  }
  cancel()
  {
    this.editForm.value.campId =this.data.campId;
    this.editForm.value.name = this.data.name;
    this.editForm.value.capacity =this.data.capacity;
    this.editForm.value.rate = this.data.rate;
    this.editForm.value.description = this.data.description;
    this.editForm.value.url = this.data.url;
    this.editForm.value.status="Available";
    this.auth.editCamp(this.editForm.value).subscribe(res => {
      alert("Booking Canceled!");
    });
    this.auth.cancelBooking(this.searchForm.value.referenceNo).
    subscribe(res=> {
      this.show=false;
    })
  }
  rateUs()
  {
    this.ratingForm.value.campId=this.data.campId;
    this.ratingForm.value.totalRating=this.currentRate;
    this.ratingForm.value.numberRating=0;
    this.ratingForm.value.averageRating=0;
    this.auth.postRating(this.ratingForm.value).
    subscribe(res=> {
      this.show=false;
    })
  }

}
