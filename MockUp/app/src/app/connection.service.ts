import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Rules } from './src/models/rules.model';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
  rules: Rules = new Rules('none',8,8,'Individual',5,30,'none');

  constructor(private http: HttpClient) { }

  // POSTs something in the server
  Post(val:any,postURL: string){
    return this.http.post<any>(postURL,val,{
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      })
    });
  }

  // PUT allows to update a value via an id
  Put(val:any,updateURL: string){
    return this.http.put<boolean>(updateURL,val);
  }

  // GETs something from the server
  Get(getURL: string){
    return this.http.get<any>(getURL);
  }

  // DELETES something from the server
  Delete(val:any,deleteURL: string){
    return this.http.delete(deleteURL,val);
  }
}
