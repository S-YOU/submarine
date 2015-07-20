﻿using System.Collections;
using UniRx;

namespace TyphenApi
{
    public partial class WebApiRequest<ResponseT, ErrorT>
        where ResponseT : TypeBase, new()
        where ErrorT : TypeBase, new()
    {
        public IObservable<WebApiResponse<ResponseT>> Send()
        {
            var completeObservable = Observable.FromCoroutine<WebApiResponse<ResponseT>>(AfterSendAsync);
            return SendAsync().ToObservable().SelectMany(completeObservable);
        }

        IEnumerator AfterSendAsync(IObserver<WebApiResponse<ResponseT>> observer)
        {
            if (Error == null)
            {
                observer.OnNext(Response);
                observer.OnCompleted();
            }
            else
            {
                observer.OnError(Error);
            }

            yield break;
        }
    }
}
