import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private apiUrl = 'https://localhost:7225/api';
  //getAllDepartments: any;
  //getStaffSalaries: any;

  constructor(private http: HttpClient) { }

  options: any = {
    responseType: 'text'
  }

  getStudentReport(id: number):Observable<any> {
    return this.http.get<string>(`${this.apiUrl}/students/report/${id}`, this.options);
  }

  downloadFileObject(base64String: string, fileName:string) {
    const linkSource = "data:application/pdf;base64,"  + base64String;
    const downloadLink = document.createElement("a");
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
  }


}

