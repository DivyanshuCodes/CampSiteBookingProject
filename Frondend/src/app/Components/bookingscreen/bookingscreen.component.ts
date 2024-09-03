import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-bookingscreen',
  templateUrl: './bookingscreen.component.html',
  styleUrls: ['./bookingscreen.component.css']
})
export class BookingscreenComponent implements OnInit {
  campDetails: any = {}
  firstObj: any = {}
  secondOnj: any = {}
  BookForm!: FormGroup
  editForm!: FormGroup
  firstFormGroup !: FormGroup
  secondFormGroup!: FormGroup
  multi: number = 0
  isLinear = false;
  Date1: any
  Date2: any
  Days: any
  refer: any
  minDate: any = new Date();
  minDate1: any = new Date();
  next: boolean = false;
  cOut: any;
  message: any = ""
  done: boolean = false;
  actual:any;
  constructor(private formBuilder: FormBuilder, private auth: AuthService) { }

  ngOnInit(): void {
    this.callData()
    this.BookForm = this.formBuilder.group({
      campId: ['', Validators.required], name: ['', Validators.required], rate: ['', Validators.required],
      capacity: ['', Validators.required], description: ['', Validators.required], url: ['', Validators.required]
    })
    this.firstFormGroup = this.formBuilder.group({
      billingAddress: ['', Validators.required], state: ['', Validators.required], country: ['', Validators.required],
      zipCode: ['', Validators.required], cellPhone: ['', Validators.required]
    });
    this.secondFormGroup = this.formBuilder.group({
      billingAddress: ['', Validators.required], state: ['', Validators.required], country: ['', Validators.required],
      zipCode: ['', Validators.required], cellPhone: ['', Validators.required], referenceNo: [''], campId: [''],
      totalStay: ['', Validators.required], totalAmount: ['', Validators.required]
    });
    this.editForm = this.formBuilder.group({
      campId: ['', Validators.required], name: ['', Validators.required,], rate: ['', Validators.required],
      capacity: ['', Validators.required], description: ['', Validators.required], url: ['', Validators.required]
      , status: ['']
    })
  }
  CalculateDays() {
    const Date1Modified = new Date(this.Date1);
    const Date2Modified = new Date(this.Date2);
    const Time = Date2Modified.getTime() - Date1Modified.getTime();
    this.Days = (Time / (1000 * 3600 * 24)) + 1;
    this.multi = this.Days * parseInt(this.campDetails.rate);
    this.actual=this.multi;
    if (this.Days == null || this.Days < 3) {
      this.message = "No coupon applied!"
    }
    else if (this.Days >= 3 && this.Days < 5) {
      this.message = "DISC1000"
      this.multi = this.multi - 1000;
      this.done = true
    }
    else if (this.Days >= 5) {
      this.message = "DISC1500"
      this.multi = this.multi - 1500;
      console.log(this.multi)
      this.done = true
    }
    else {
      this.message = "Invalid coupon"
    }


    let x = Math.floor((Math.random() * 100000000) + 1);
    this.refer = x.toString()
    this.secondFormGroup.value.billingAddress = this.firstFormGroup.value.billingAddress;
    this.secondFormGroup.value.state = this.firstFormGroup.value.state;
    this.secondFormGroup.value.country = this.firstFormGroup.value.country;
    this.secondFormGroup.value.zipCode = this.firstFormGroup.value.zipCode;
    this.secondFormGroup.value.cellPhone = this.firstFormGroup.value.cellPhone;
    this.secondFormGroup.value.referenceNo = this.refer;
    this.secondFormGroup.value.campId = this.campDetails.campId;
    this.secondFormGroup.value.totalStay = this.Days;
    this.secondFormGroup.value.totalAmount = this.multi;
    console.log(this.secondFormGroup.value);
  }
  callData() {
    this.campDetails = this.auth.getData();
  }
  firstSubmit() {
    this.firstObj = this.firstFormGroup.value;
    console.log(this.firstObj);
  }
  secondSubmit() {
    this.CalculateDays();
    this.auth.addBooking(this.secondFormGroup.value).subscribe(res => {
      alert("Details uploaded");
      this.campDetails.status = "Booked";
    });
    this.editForm.value.campId = this.campDetails.campId;
    this.editForm.value.name = this.campDetails.name;
    this.editForm.value.capacity = this.campDetails.capacity;
    this.editForm.value.rate = this.campDetails.rate;
    this.editForm.value.description = this.campDetails.description;
    this.editForm.value.url = this.campDetails.url;
    this.editForm.value.status = "Booked";

    this.auth.editCamp(this.editForm.value).subscribe(res => {
      alert("Camp Booked!");
      this.next = true;
    });
  }
  setMin() {
    this.minDate1 = this.Date1;
  }
  discount(Days: any) {

  }
}
