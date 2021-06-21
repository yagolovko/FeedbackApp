import { Injectable } from '@angular/core';
import { Feedback, DbTheme } from './feedback.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'http://localhost:63288/api/Feedback'
  readonly themeURL = 'http://localhost:63288/api/Feedback/theme'
  formData: Feedback = new Feedback();
  list: Feedback[];
  listTheme: DbTheme[];

  postFeedback() {
    return this.http.post(this.baseURL, this.formData);
  }

  refreshList() {
    this.http.get(this.baseURL).subscribe(res => {
      this.list = res as Feedback[];
      // Берем последнее обращение
      var last = this.list.reverse()[0]
      this.list = [last];
    });

  }
  getThemes() {
    this.http.get(this.themeURL).subscribe(res => {
      this.listTheme = res as DbTheme[];
    });

  }


}
