import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {

  constructor(private http: HttpClient) { }

  // POSTs something in the server
  Post(val:any,postURL: string){
    return this.http.post<any>(postURL,val);
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
