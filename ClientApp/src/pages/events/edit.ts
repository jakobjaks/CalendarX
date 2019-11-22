import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {EventService} from "../../services/events-service";
import {IEvent} from "../../interfaces/IEvent";

export var log = LogManager.getLogger('Event.Delete');

@autoinject
export class Delete {

  private event: IEvent | null = null;

  constructor(
    private router: Router,
    private eventService: EventService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============
  submit():void{
    log.debug('event', this.event);
    this.eventService.put(this.event!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("EventsIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
  }


  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);

    this.eventService.fetch(params.id).then(
      event => {
        log.debug('administrativeUnit', event);
        this.event = event;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
