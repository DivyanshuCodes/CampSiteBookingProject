import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-adminview',
  templateUrl: './adminview.component.html',
  styleUrls: ['./adminview.component.css']
})
export class AdminviewComponent implements OnInit {
  Data!: any;
  obj: any = {}
  campForm!: FormGroup;
  editForm!: FormGroup;
  status:string="Available"
  p:any
  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router, private auth: AuthService) { }

  ngOnInit(): void {

    this.showCampData()
    this.campForm=new FormGroup({

      campId: new FormControl("",[Validators.required,Validators.pattern('[0-9]*')]),
      name:new FormControl("",[Validators.required,Validators.minLength(5),Validators.pattern('[a-z A-Z]+[a-z A-Z]*')]),
      rate:new FormControl("",[Validators.required,Validators.minLength(3),Validators.pattern('[0-9]*')]),
      capacity:new FormControl("",[Validators.required,Validators.minLength(1),Validators.pattern('[0-9]*')]),
      description:new FormControl("",[Validators.required,Validators.minLength(5),Validators.maxLength(250)]),
      url:new FormControl("",[Validators.required]),
      status:new FormControl([''])
    });
    // this.campForm = this.formBuilder.group({
    //   campId: ['', Validators.required], name: ['', Validators.required,Validators.pattern('[a-zA-Z]*')], rate: ['', Validators.required],
    //   capacity: ['', Validators.required], description: ['', Validators.required], url: ['', Validators.required],
    //   status:['']
    // })
    this.editForm = new FormGroup({
      campId: new FormControl("",[Validators.required,Validators.pattern('[0-9]*')]),
      name:new FormControl("",[Validators.required,Validators.minLength(5),Validators.pattern('[a-z A-Z]+[a-z A-Z]*')]),
      rate:new FormControl("",[Validators.required,Validators.minLength(3),Validators.pattern('[0-9]*')]),
      capacity:new FormControl("",[Validators.required,Validators.minLength(1),Validators.pattern('[0-9]*')]),
      description:new FormControl("",[Validators.required,Validators.minLength(5)]),
      url:new FormControl("",[Validators.required,Validators.minLength(5),Validators.pattern('[Hh][Tt][Tt][Pp][Ss]?:\/\/(?:(?:[a-zA-Z\u00a1-\uffff0-9]+-?)*[a-zA-Z\u00a1-\uffff0-9]+)(?:\.(?:[a-zA-Z\u00a1-\uffff0-9]+-?)*[a-zA-Z\u00a1-\uffff0-9]+)*(?:\.(?:[a-zA-Z\u00a1-\uffff]{2,}))(?::\d{2,5})?(?:\/[^\s]*)?')]),
      status:new FormControl([''])
    })
  }

  showCampData() {
    
    this.auth.viewCamp().subscribe((res: any) => {
      this.Data = res;
    })
  }
  delCamp(data: any) {
    this.auth.deleteCamp(data).subscribe(res => {
      console.log(res);
      alert("Camp deleted");
      this.showCampData();
    });
  }
  onCampCreate() {
    this.campForm.value.status=this.status;
    console.warn(this.campForm.value);
    this.auth.createCamp(this.campForm.value).
      subscribe(res => {
        console.log(res);
        alert("Camp Created");
        this.showCampData();
      });
  }
  updateCamp(data: any) {
    this.obj=data;    
    this.editForm.value.campId =this.obj.campId;
    this.editForm.value.name = this.obj.name;
    this.editForm.value.capacity =this.obj.capacity;
    this.editForm.value.rate = this.obj.rate;
    this.editForm.value.description = this.obj.description;
    this.editForm.value.url = this.obj.url;
    this.editForm.value.status=this.status;
    this.editForm.controls['campId'].setValue(data.campId);
    this.editForm.controls['name'].setValue(data.name);
    this.editForm.controls['rate'].setValue(data.rate);
    this.editForm.controls['capacity'].setValue(data.capacity);
    this.editForm.controls['description'].setValue(data.description);
    this.editForm.controls['url'].setValue(data.url);
    this.editForm.controls['status'].setValue(this.status);
  }
  editCamp() {
    
    console.warn(this.editForm.value);
    this.auth.editCamp(this.editForm.value).
      subscribe(res => {
        console.log(res);
        alert("Camp updated");
        this.showCampData();
      });
      
    }
}
