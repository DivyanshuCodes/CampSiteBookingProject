import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  obj:any={};
  campObj:any={};
  bookObj:any;
  private baseUrl:string="http://localhost:51060/api/User/";
  private Url:string="http://localhost:51060/api/Person/";
  private campUrl:string="http://localhost:51060/api/Camp/";
  private bookingUrl:string="http://localhost:51060/api/Booking/";
  private ratingUrl:string="http://localhost:51060/api/Rating/";
  constructor(private http:HttpClient) { }
  
 
  signUp(userObj:any)
  {
    //return this.http.post<any>(`${this.baseUrl}register`,userObj);
    return this.http.post<any>(`${this.Url}postUser`,userObj);
  }
  login(loginObj:any)
  {
    return this.http.post<any>(`${this.Url}getUser`,loginObj);
  }
  createCamp(campObj:any)
  {
    return this.http.post<any>(`${this.campUrl}postCamp`,campObj);
  }
  viewCamp()
  {
    this.obj=this.http.get<any>(`${this.campUrl}getCamp`);
    return this.obj;
  }
  deleteCamp(campObj:any)
  {
    return this.http.post<any>(`${this.campUrl}deleteCamp`,campObj);
  }
  editCamp(campObj:any)
  {
    return this.http.post<any>(`${this.campUrl}editCamp`,campObj);
  }
  setData(data:any)
  {
  this.campObj=data;
  }
  getData()
  {
    return this.campObj;
  }
  addBooking(data:any)
  {
    return this.http.post<any>(`${this.bookingUrl}addBooking`,data);
  }
  findBooking(data:any)
  {
    this.bookObj=data.toString();
    return this.http.get<any>(`${this.bookingUrl}findBooking/`+this.bookObj);
  }
  cancelBooking(ref:any)
  {
    return this.http.delete<any>(`${this.bookingUrl}cancelBooking/`+ref);
  }
  postRating(data:any)
  {
    return this.http.post<any>(`${this.ratingUrl}postRating`,data);
  }
  IsLoggedIn(){

    return !!localStorage.getItem('token');

  }
}
