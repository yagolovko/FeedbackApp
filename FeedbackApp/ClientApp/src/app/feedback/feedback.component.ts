import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../shared/feedback.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styles: [
  ],
})
export class FeedbacksComponent implements OnInit {

  constructor(public service: FeedbackService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

}
