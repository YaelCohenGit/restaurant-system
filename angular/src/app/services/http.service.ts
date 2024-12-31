import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  httpOptions: { headers: HttpHeaders; };
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:64933/';
  get(route: string, parameter: any = null): Observable<any> {
    if (parameter != null) {
      return this.http.get(this.baseUrl + route, parameter);
    }
    return this.http.get(this.baseUrl + route);
  }
  post(route: string, parameter: any = null): Observable<any> {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    if (parameter instanceof (Object)) {
      return this.http.post(this.baseUrl + route, parameter);
    }
    else {
      return this.http.post(this.baseUrl + route, parameter, this.httpOptions);
    }
  }
}
