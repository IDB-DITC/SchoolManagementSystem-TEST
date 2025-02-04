import { Component, OnInit, inject } from '@angular/core';
import { Student } from '../../../Models/student';
import { FilterSettingsModel, PageSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { StudentService } from '../../../Services/student.service';
import { Router } from '@angular/router';
import { ReportService } from '../../../Services/report.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.css'
})
export class ListStudentComponent implements OnInit {

  public students: Student[] = [];
  public studentId!: number;
  public pageSettings: PageSettingsModel = { pageSize: 3 };
  public filterSettings: FilterSettingsModel = { type: 'FilterBar' };//Menu, Excel, FilterBar
  public toolbarOptions?: ToolbarItems[] = ['Search',
    'Print',
    'ColumnChooser',
    //'PdfExport',
    //'ExcelExport',
    //'CsvExport'
  ];

  private report = inject(ReportService);


  constructor(private studentService: StudentService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {

    this.studentService.GetStudents().subscribe(
      staffs => {
        this.students = staffs;
      },

      //this.studentService.GetStudents().subscribe(
      //  (response: Student[]) => {
      //    this.students = response;
      //  },
      (error) => {
        console.log('Observable emitted an error: ' + error);
      }
    );
  }

  deleteStudent(student: Student): void {
    const confirmDelete: boolean = confirm(`Delete: ${student.studentName}?`);
    if (confirmDelete) {
      this.studentService.DeleteStudent(student.studentId).subscribe(
        () => {
          this.loadData();
        },
        (error) => {
          console.log('Observable emitted an error: ' + error);
        }
      );
    }
  }


  downloadReport(sudentId: number) {
    this.report.getStudentReport(sudentId).subscribe(
      (response) => {
        console.log(response);
        this.report.downloadFileObject(response, `Report-${sudentId}.pdf`);
      },
      (error) => {
        console.log('Observable emitted an error: ' + error.error);
        console.log( error );
      }
    );
  }


}

