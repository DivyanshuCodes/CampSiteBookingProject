import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm!: FormGroup;
  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router, private auth: AuthService) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required], password: ['', Validators.required]
    })
  }

  onLogin() {
    // console.warn(this.loginForm.value);
    this.auth.login(this.loginForm.value).
      subscribe(res => {
          console.log(res);
          alert("Login Success");
       
localStorage.setItem('token',"BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!BOOOM!")
          this.router.navigate(['/admin'])
        
      })
  }
}
