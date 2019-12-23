import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {TargetAudienceService} from "../../services/targetaudiences-service";
import {ITargetAudience} from "../../interfaces/ITargetAudience";

export var log = LogManager.getLogger('ContactTypes.Details');

@autoinject
export class Details {

  private targetAudience: ITargetAudience | null = null;

  constructor(
    private router: Router,
    private targetAudienceService: TargetAudienceService
  ) {
    log.debug('constructor');
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
    this.targetAudienceService.fetch(params.id).then(
      targetAudience => {
        log.debug('contactType', targetAudience);
        this.targetAudience = targetAudience;
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
