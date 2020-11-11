import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiCollectionResult, ApiSingleResult } from '../Models/apiResult';

@Injectable({
  providedIn: 'root'
})
export class TitleService {

  constructor(private http: HttpClient) { }

  getTitles(): Observable<ApiCollectionResult> {
    return this.http.get<ApiCollectionResult>("https://localhost:44316/api/Title");
  }

  getTitle(id: number): Observable<ApiSingleResult>{
    return this.http.get<ApiSingleResult>("https://localhost:44316/api/Title/getTitle/"+id);
  }
}
