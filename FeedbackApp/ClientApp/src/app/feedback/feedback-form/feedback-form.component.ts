import { Component, OnInit } from '@angular/core';
import { FeedbackService } from 'src/app/shared/feedback.service';
import { NgForm } from '@angular/forms';
import { Feedback } from 'src/app/shared/feedback.model';
import { ToastrService } from 'ngx-toastr';
import { RecaptchaErrorParameters } from "ng-recaptcha"



@Component({
  selector: 'app-feedback-form',
  templateUrl: './feedback-form.component.html',
  styles: [
  ],
})

export class FeedbackFormComponent implements OnInit {

  constructor(public service: FeedbackService,
    private toastr: ToastrService) { }

  public captchaResponse = "";

  public resolved(captchaResponse: string): void {
    const newResponse = captchaResponse
      ? `${captchaResponse.substr(0, 7)}...${captchaResponse.substr(-7)}`
      : captchaResponse;
    this.captchaResponse += `${JSON.stringify(newResponse)}\n`;
  }

  public onError(errorDetails: RecaptchaErrorParameters): void {
    this.captchaResponse += `ERROR; error details (if any) have been logged to console\n`;
    console.log(`reCAPTCHA error encountered; details:`, errorDetails);
  }
  ngOnInit(): void {
    this.service.getThemes();
  }
  onSubmit(form: NgForm) {
    this.insertRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postFeedback().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Успешно!', 'Сообщение добавлено')
      },
      err => { console.log(err); }
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Feedback();
  }

}
