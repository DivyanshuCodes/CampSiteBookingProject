import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatToolbar, MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { BookingscreenComponent } from './Components/bookingscreen/bookingscreen.component';

import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { AuthService } from './services/auth.service';
import { SignupComponent } from './Components/signup/signup.component';
import { LoginComponent } from './Components/login/login.component';
import { AdminviewComponent } from './Components/adminview/adminview.component';
import { MatStepperModule } from '@angular/material/stepper';
import { MatTabsModule } from '@angular/material/tabs';
import { NgxPaginationModule } from 'ngx-pagination';
import { FilterPipe } from './Pipes/filter.pipe';
import { TrialComponent } from './Components/trial/trial.component';
import { ManageBookingComponent } from './Components/manage-booking/manage-booking.component';
import { SortPipe } from './Pipes/sort.pipe';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';
import { LogoutComponent } from './Components/logout/logout.component';


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    BookingscreenComponent,
    SignupComponent,
    LoginComponent,
    AdminviewComponent,
    FilterPipe,
    TrialComponent,
    ManageBookingComponent,
    SortPipe,
    LogoutComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,
    MatToolbarModule, 
    MatIconModule,
     MatButtonModule, 
     ReactiveFormsModule, 
     HttpClientModule, 
     MatTabsModule,
      NgxPaginationModule,
       MatStepperModule,FormsModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
